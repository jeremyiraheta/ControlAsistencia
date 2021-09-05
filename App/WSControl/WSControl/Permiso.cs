using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSControl.modelos;

namespace WSControl
{
    public partial class Permiso : Form
    {
        private int codper = 0;
        private string file;
        public Permiso()
        {
            InitializeComponent();
        }
        public Permiso(int codper,string fecha, char tipo, string horainicial, string horafinal, string descripcion, char estado, bool attch)
        {
            InitializeComponent();
            this.codper = codper;
            CultureInfo provider = CultureInfo.InvariantCulture;
            c_tpFecha.Value = DateTime.ParseExact(fecha,"dd/MM/yyyy", provider);
            switch (tipo)
            {
                case 'O':
                    c_cmbTipo.SelectedIndex = 1;
                    break;
                case 'S':
                    c_cmbTipo.SelectedIndex = 2;
                    break;
                default:
                    c_cmbTipo.SelectedIndex = 0;
                    break;
            }
            c_btnSolicitar.Enabled = false;
            c_btnAdjuntar.Enabled = false;
            switch (estado)
            {
                case 'E':
                    c_btnAdjuntar.Enabled = true;
                    c_btnSolicitar.Enabled = true;
                    break;
                default:
                    break;
            }
            c_cmbTipo.Refresh();
            c_tpHoraInicial.Value = DateTime.Parse(horainicial);
            c_tpHoraFinal.Value = DateTime.Parse(horafinal);
            c_txtDescripcion.Text = descripcion;
            if (attch)
                c_linkDescargar.Visible = true;
        }
        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Permiso_Load(object sender, EventArgs e)
        {
            if(c_cmbTipo.SelectedIndex == -1)
                c_cmbTipo.SelectedIndex = 0;
        }

        private void c_btnSolicitar_Click(object sender, EventArgs e)
        {
            API<LastID> api = new API<LastID>();
            Permisos permiso = new Permisos();
            permiso.codemp = Login.codemp;
            permiso.descripcion = c_txtDescripcion.Text;
            permiso.fecha = c_tpFecha.Value.ToString("dd-MM-yyyy");
            permiso.horainicial = c_tpHoraInicial.Value.ToString("HH:mm");
            permiso.horafinal = c_tpHoraFinal.Value.ToString("HH:mm");
            permiso.estado = 'E';
            if (c_cmbTipo.SelectedIndex == 0)
                permiso.tipo = 'P';
            else if(c_cmbTipo.SelectedIndex == 1)
                permiso.tipo = 'O';
            else if(c_cmbTipo.SelectedIndex == 2)
                permiso.tipo = 'S';
            Task<LastID> task = null;           
            if (codper == 0)
            {
                task = Task.Run(() => api.post("permisos", permiso));
                codper = task.Result.insertId;
            }                
            else
                task = Task.Run(() => api.put($"permisos/{codper}", permiso));
            task.Wait();                        
            if (c_dlgAdj.FileNames.Length > 0)
            {
                API<UploadState> api2 = new API<UploadState>();
                var task2 = Task.Run(() => api2.post($"upload/{codper}", c_dlgAdj.FileName, "attch"));
                task2.Wait();
                UploadState result = task2.Result;
                if(!result.status)
                    MessageBox.Show(this, result.message, "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void c_btnAdjuntar_Click(object sender, EventArgs e)
        {
            if(c_dlgAdj.ShowDialog(this) == DialogResult.OK)
            {
                file = c_dlgAdj.FileName;
                FileInfo fi = new FileInfo(file);
                if (ToSize(fi.Length, SizeUnits.MB) >  20)
                    MessageBox.Show(this, "El archivo no debe exceder los 20MB!!!", "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (fi.Extension.ToLower() == ".zip")
                    {
                        c_lfile.Text = "Adjunto: " + fi.Name;
                        c_linkDescargar.Visible = false;
                    }
                    else
                        MessageBox.Show(this, "El formato no es valido!!!", "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }
        private void c_linkDescargar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            API api = new API();
            if(c_dlgSave.ShowDialog() == DialogResult.OK)
            {
                var task = Task.Run(() => api.download($"download/{codper}"));
                task.Wait();
                BinaryWriter writer = new BinaryWriter(c_dlgSave.OpenFile());
                writer.Write(task.Result);
                writer.Flush();
                writer.Close();
                System.Diagnostics.Process.Start("explorer.exe", c_dlgSave.FileName);
            }                        
        }
        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public double ToSize(Int64 value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));
        }
        class UploadState
        {
            public bool status { get; set; }
            public string message { get; set; }
            public UploadState()
            {

            }
        }
        class LastID
        {
            public int insertId { get; set; }
        }       
    }
}
