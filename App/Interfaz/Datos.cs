using Interfaz.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    /// <summary>
    /// Interfaz que expone acceso a datos
    /// </summary>
    public class Datos
    {
        private static Boolean local = true;
        private static string token;     
        public static string APIURL
        {
            get
            {
                return new API(local, token).URLBASE;
            }
        }
        private Datos()
        {
            
        }

        /// <summary>
        /// La api apunta a direccion remota
        /// </summary>
        public static void apiRemota(string tkn = "YWRtaW46YWRtaW4=")
        {
            local = false;
            token = tkn;
        }
        /// <summary>
        /// La api apunta a direccion local default
        /// </summary>
        public static void apiLocal(string tkn = "YWRtaW46YWRtaW4=")
        {
            local = true;
            token = tkn;
        }

        /// <summary>
        /// Inserta nuevo departamento
        /// </summary>
        /// <param name="nombre">nombre departamento</param>
        public static Result insertDepartamento(int codcli, string nombre)
        {
            API<Result> api = new API<Result>(local, token);
            Departamento dep = new Departamento();
            dep.nombre = nombre;
            dep.codcli = codcli;
            var t = Task.Run(() => api.post("departamentos", dep));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Obtiene todos los departamentos
        /// </summary>
        /// <returns>Listado de departamentos</returns>
        public static List<Departamento> listDepartamentos(int codcli)
        {
            API<List<Departamento>> api = new API<List<Departamento>>(local, token);
            var t = Task.Run(() => api.get($"departamentos/codcli/{codcli}"));
            return t.Result;
        }
        /// <summary>
        /// Actualiza un departamento
        /// </summary>
        /// <param name="coddpto">codigo departamento</param>
        /// <param name="nombre">nombre departamento</param>
        public static Result updateDepartamento(int coddpto, int codcli,string nombre)
        {
            API<Result> api = new API<Result>(local, token);
            Departamento dep = new Departamento();
            dep.nombre = nombre;
            var t = Task.Run(() => api.put($"departamentos/coddpto/{coddpto}/codcli/{codcli}", dep));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Elimina un departamento
        /// </summary>
        /// <param name="coddpto">codigo departamento</param>
        public static Result deleteDepartamento(int coddpto, int codcli)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.delete($"departamentos/coddpto/{coddpto}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Obtiene un departamento por id
        /// </summary>
        /// <param name="coddpto">codigo departamento</param>
        /// <returns></returns>
        public static List<Empleado> getEmpleadosDpto(int coddpto, int codcli)
        {
            API<List<Empleado>> api = new API<List<Empleado>>(local,token);
            var t = Task.Run(() => api.get($"departamentos/coddpto/{coddpto}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Filtra una tabla en relacion a una condicion
        /// </summary>
        /// <param name="table">nombre de la tabla</param>
        /// <param name="cond">condicion</param>
        /// <returns></returns>
        public static List<T> filter<T>(string table, string cond, string fields = null)
        {
            API<List<T>> api = new API<List<T>>(local, token);
            Filter f = new Filter();
            f.query = cond;
            f.fields = fields;
            var t = Task.Run(() => api.post("query/" + table, f));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Inserta un nuevo empleado
        /// </summary>
        /// <param name="empleado">nuevo empleado</param>
        public static Result insertEmpleado(Empleado empleado)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.post("empleados", empleado));
            try
            {
                t.Wait();
                var r = t.Result;
                if (t.Status == TaskStatus.RanToCompletion && r != null)
                    return r;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Obtiene todos los empleados
        /// </summary>
        /// <returns>Listado de empleados</returns>
        public static List<Empleado> listEmpleados(int codcli, int pagina = -1, bool activo = true)
        {
            API<List<Empleado>> api = new API<List<Empleado>>(local,token);
            if (pagina == -1)
            {
                var t = Task.Run(() => api.get($"empleados/codcli/{codcli}?activo={activo}"));
                t.Wait();
                return t.Result;
            }
            else
            {
                var t = Task.Run(() => api.get($"empleados/codcli/{codcli}/p/{pagina}?activo={activo}"));
                t.Wait();
                return t.Result;
            }
        }
        /// <summary>
        /// Obtiene todos los empleados de un departamento
        /// </summary>
        /// <returns>Listado de empleados</returns>
        public static List<Empleado> listEmpleadosDpto(int codcli, int coddpto,bool activo = true)
        {
            API<List<Empleado>> api = new API<List<Empleado>>(local,token);
            var t = Task.Run(() => api.get($"empleados/codcli/{codcli}/coddpto/{coddpto}?activo={activo}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Obtiene un empleado por su id
        /// </summary>
        /// <param name="codemp">codigo empleado</param>
        /// <returns></returns>
        public static Empleado getEmpleado(int codemp, int codcli)
        {
            API<List<Empleado>> api = new API<List<Empleado>>(local,token);
            var t = Task.Run(() => api.get($"empleados/codemp/{codemp}/codcli/{codcli}"));
            t.Wait();
            return t.Result[0];
        }
        /// <summary>
        /// Obtiene un empleado por su usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="codcli"></param>
        /// <returns></returns>
        public static Empleado getEmpleado(string usuario, int codcli)
        {
            API<List<Empleado>> api = new API<List<Empleado>>(local,token);
            var t = Task.Run(() => api.get($"empleados/usuario/{usuario}/codcli/{codcli}"));
            t.Wait();
            try
            {
                return t.Result[0];
            }
            catch (Exception)
            {
                return null;
            }            
        }
        /// <summary>
        /// Actualiza un empleado especifico
        /// </summary>
        /// <param name="codemp">codigo empleado</param>
        /// <param name="empleado">objeto editado del empleado</param>
        public static Result updateEmpleado(Empleado empleado)
        {
            API<Result> api = new API<Result>(local,token);
            var t = Task.Run(() => api.put("empleados", empleado));
            try
            {
                t.Wait();
                var r = t.Result;
                if (t.Status == TaskStatus.RanToCompletion && r != null)
                    return r;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;                
            }
        }
        /// <summary>
        /// Desactiva un empleado
        /// </summary>
        /// <param name="codemp">codigo empleado</param>
        public static Result disableEmpleado(int codemp, int codcli)
        {
            API<Result> api = new API<Result>(local,token);
            var t = Task.Run(() => api.delete($"empleados/codemp/{codemp}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Activa un empleado
        /// </summary>
        /// <param name="codemp">codigo empleado</param>
        public static Result enableEmpleado(int codemp, int codcli)
        {
            API<Result> api = new API<Result>(local,token);
            var t = Task.Run(() => api.put($"empleados/codemp/{codemp}/codcli/{codcli}/enable"));
            t.Wait();
            return t.Result;
        }
        
        /// <summary>
        /// Obtiene los registros de un empleado
        /// </summary>
        /// <param name="codemp">codigo de empleado</param>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public static List<Registro> listRegistros(int codemp, int codcli)
        {
            API<List<Registro>> api = new API<List<Registro>>(local,token);
            var t = Task.Run(() => api.get($"registros/codemp/{codemp}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }

        public static List<Registro> listRegistrosMes(int codcli, int mes, int anio)
        {
            API<List<Registro>> api = new API<List<Registro>>(local,token);
            var t = Task.Run(() => api.get($"registros/codcli/{codcli}/m/{String.Format("{0:00}", mes)}/y/{anio}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Ontiene un listado de registros de un empleado un mes especifico
        /// </summary>
        /// <param name="codemp"></param>
        /// <param name="mes"></param>
        /// <param name="anio"></param>
        /// <returns></returns>
        public static List<Registro> listRegistrosEmpleado(int codemp, int codcli, int mes, int anio)
        {
            API<List<Registro>> api = new API<List<Registro>>(local,token);
            var t = Task.Run(() => api.get($"registros/codemp/{codemp}/codcli/{codcli}/m/{String.Format("{0:00}", mes)}/y/{anio}"));
            t.Wait();
            return t.Result;
        }

        public static Result tickRegistro(int codemp, int codcli, bool crear)
        {
            API<Result> api = new API<Result>(local,token);
            Task<Result> r;
            if(crear)
                r = Task.Run(() => api.post($"registros/codemp/{codemp}/codcli/{codcli}"));
            else
                r = Task.Run(() => api.put($"registros/codemp/{codemp}/codcli/{codcli}"));
            r.Wait();
            return r.Result;
        }

        /// <summary>
        /// Obtiene todos los permisos
        /// </summary>
        /// <returns>Listado de permisos</returns>
        public static List<Permiso> listPermisos(int codcli, int mes, int anio)
        {
            API<List<Permiso>> api = new API<List<Permiso>>(local,token);
            var t = Task.Run(() => api.get($"permisos/codcli/{codcli}/m/{String.Format("{0:00}", mes)}/y/{anio}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Obtiene un permiso particular
        /// </summary>
        /// <param name="codemp">codigo de empleado</param>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public static List<Permiso> listPermisos(int codemp, int codcli)
        {
            API<List<Permiso>> api = new API<List<Permiso>>(local, token);
            var t = Task.Run(() => api.get($"permisos/codemp/{codemp}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Obtiene un permiso particular
        /// </summary>
        /// <param name="codemp">codigo de empleado</param>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public static Permiso getPermiso(int codper, int codcli)
        {
            API<List<Permiso>> api = new API<List<Permiso>>(local, token);
            var t = Task.Run(() => api.get($"permisos/codper/{codper}/codcli/{codcli}"));
            t.Wait();
            return t.Result[0];
        }

        /// <summary>
        /// Inserta un permiso nuevo
        /// </summary>
        /// <param name="permiso">nuevo permiso</param>
        public static Result insertPermiso(Permiso permiso)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.post("permisos", permiso));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Actualiza un permiso
        /// </summary>
        /// <param name="codper">codigo del permiso</param>
        /// <param name="permiso">permiso editado</param>
        public static Result updatePermiso(int codper, Permiso permiso)
        {
            API<Result> api = new API<Result>(local, token);
            permiso.codper = codper;
            var t = Task.Run(() => api.put("permisos", permiso));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Cambia el estado de un permiso
        /// </summary>
        /// <param name="codper">codigo del permiso</param>
        /// <param name="estado">estado</param>
        public static Result cambiarEstadoPermiso(int codper, int codcli,ESTADO estado)
        {
            API<Result> api = new API<Result>(local, token);
            string c = "E";
            switch (estado)
            {
                case ESTADO.ESPERA:
                    c = "E";
                    break;
                case ESTADO.APROBADO:
                    c = "A";
                    break;
                case ESTADO.RECHAZADO:
                    c = "R";
                    break;
                default:
                    break;
            }
            var t = Task.Run(() => api.put($"permisos/codper/{codper}/codcli/{codcli}/estado/{c}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Elimina un permiso
        /// </summary>
        /// <param name="codper">codigo del permiso</param>
        public static Result deletePermiso(int codper, int codcli)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.delete($"permisos/codper/{codper}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }

        /// <summary>
        /// Obtiene registros de productividad de un empleado
        /// </summary>
        /// <param name="codemp">codigo empleado</param>
        /// <param name="codcli">codigo cliente</param>
        /// <param name="fechaini">fecha inicial</param>
        /// <param name="fechafin">fecha final</param>
        /// <returns></returns>
        public static List<Productividad> getProductividad(int codemp, int codcli, string fechaini, string fechafin)
        {
            API<List<Productividad>> api = new API<List<Productividad>>(local, token);
            if (System.Text.RegularExpressions.Regex.IsMatch(fechaini, "\\d{4}-\\d{2}-\\d{2}"))
            {
                String[] fi = fechaini.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                String[] fe = fechafin.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                fechaini = String.Format("{0:00}-{1:00}-{2}", fi[2], fi[1], fi[0]);
                fechafin = String.Format("{0:00}-{1:00}-{2}", fe[2], fe[1], fe[0]);
            }
            var t = Task.Run(() => api.get($"productividad/codemp/{codemp}/codcli/{codcli}/fechaini/{fechaini}/fechafin/{fechafin}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Crea un registro de productividad
        /// </summary>
        /// <param name="productividad">Entidad de productividad</param>
        public static Result insertProductividad(Productividad productividad)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.post("productividad",productividad));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Actualiza un registro de productividad
        /// </summary>
        /// <param name="productividad">Entidad que debe actualizarse</param>
        public static Result updateProductividad(Productividad productividad)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.put("productividad", productividad));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Elimina un registro de productividad
        /// </summary>
        /// <param name="codprod">codigo de productividad</param>
        /// <param name="codcli">codigo de cliente</param>
        public static Result deleteProductividad(int codprod, int codcli)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.delete($"productividad/codprod/{codprod}/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Consultar un cliente
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public static Cliente getCliente(int codcli)
        {
            API<List<Cliente>> api = new API<List<Cliente>>(local, token);
            var t = Task.Run(() => api.get($"clientes/codcli/{codcli}"));
            t.Wait();
            return t.Result[0];
        }

        public static Cliente getCliente(string urlnom)
        {
            API<List<Cliente>> api = new API<List<Cliente>>(local, token);
            var t = Task.Run(() => api.get($"clientes/urlnom/{urlnom}"));
            t.Wait();
            if (t.Result != null && t.Result.Count > 0)
                return t.Result[0];
            else
                return null;
        }

        /// <summary>
        /// Consulta todos los clientes
        /// </summary>
        /// <param name="pagina">no pagina</param>
        /// <returns></returns>
        public static List<Cliente> listClientes(bool activo, int pagina=0)
        {
            API<List<Cliente>> api = new API<List<Cliente>>(local, token);
            var t = Task.Run(() => api.get($"clientes/p/{pagina}?activo={activo.ToString()}"));
            t.Wait();
            return t.Result;
        }
        
        /// <summary>
        /// Ingresa un registro de cliente
        /// </summary>
        /// <param name="cliente">Entidad del cliente</param>
        public static Result insertCliente(Cliente cliente)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.post("clientes", cliente));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Actualiza un cliente
        /// </summary>
        /// <param name="cliente">Entidad que se actualizara</param>
        public static Result updateCliente(Cliente cliente)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.put("clientes", cliente));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Reactiva un cliente
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        public static Result enableCliente(int codcli)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.put($"clientes/codcli/{codcli}/enable"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Desactiva un cliente
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        public static Result deleteCliente(int codcli)
        {
            API<Result> api = new API<Result>(local, token);
            var t = Task.Run(() => api.delete($"clientes/codcli/{codcli}"));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// Elimina toda la informacion de un cliente
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        public static void purgeCliente(int codcli)
        {
            API api = new API(local, token);
            var t = Task.Run(() => api.delete($"clientes/codcli/{codcli}/purge"));
            t.Wait();
        }
        /// <summary>
        /// Permite subir un archivo adjunto al servidor
        /// </summary>
        /// <param name="codper">codigo del permiso</param>
        /// <param name="codcli">codigo de cliente</param>
        /// <param name="archivo">direccion del archivo</param>
        /// <returns></returns>
        public static UploadState uploadPermisoAdjunto(int codper, int codcli,string archivo)
        {
            API<UploadState> api = new API<UploadState>(local, token);
            var task2 = Task.Run(() => api.post($"upload/permiso/codper/{codper}/codcli/{codcli}", archivo, "application/zip", "attch"));
            task2.Wait();
            return task2.Result;
        }
        public static UploadState uploadCaptura(int codprod, int codcli, byte[] archivo)
        {
            API<UploadState> api = new API<UploadState>(local, token);                        
            var task2 = Task.Run(() => api.post($"upload/captura/codprod/{codprod}/codcli/{codcli}", archivo,"*/*", "attch"));
            task2.Wait();
            return task2.Result;
        }

        /// <summary>
        /// Subir un logo al servidor
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        /// <param name="archivo">buffer de bytes del archivo</param>
        /// <returns></returns>
        public static UploadState uploadLogo(int codcli, byte[] archivo)
        {
            API<UploadState> api = new API<UploadState>(local, token);                       
            var task2 = Task.Run(() => api.post($"upload/logo/codcli/{codcli}", archivo, "*/*", "attch"));
            task2.Wait();
            return task2.Result;
        }
        /// <summary>
        /// Permite descargar un archivo adjunto del servidor
        /// </summary>
        /// <param name="codper">codigo del permiso</param>        
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public async static Task<byte[]> downloadPermisoAdjunto(int codper, int codcli)
        {
            API api = new API(local, token);
            byte[] bytes;
            try
            {
                bytes = await Task.Run(() => api.download($"download/permiso/codper/{codper}/codcli/{codcli}"));
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }
        /// <summary>
        /// Descargar una captura de pantalla asociada a un registro de productividad
        /// </summary>
        /// <param name="codprod">codigo de productividad</param>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public async static Task<byte[]> imgCaptura(int codprod, int codcli)
        {
            API api = new API(local, token);
            byte[] bytes;
            try
            {
                bytes = await Task.Run(() => api.download($"img/captura/codprod/{codprod}/codcli/{codcli}"));
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }

        /// <summary>
        /// Descarga el logotipo del cliente
        /// </summary>
        /// <param name="codcli">codigo de cliente</param>
        /// <returns></returns>
        public async static Task<byte[]> imgLogo(int codcli)
        {
            API api = new API(local, token);
            byte[] bytes;
            try
            {
                bytes = await Task.Run(() => api.download($"img/logo/codcli/{codcli}"));
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }
        /// <summary>
        /// Permite acceder a un reporte de horas laboradas
        /// </summary>
        /// <param name="codcli">cliente</param>
        /// <param name="m">mes</param>
        /// <param name="y">anio</param>
        /// <returns></returns>
        public async static Task<byte[]> reporteHoras(int codcli, int m, int y)
        {
            API api = new API(local, token);
            Reporte rpt = new Reporte()
            {
                codcli = codcli,
                m = m,
                y = y
            };
            byte[] bytes;
            try
            {
                bytes = await Task.Run(() => api.download($"reporteHoras.pdf", rpt) );
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }

        /// <summary>
        /// Permite acceder a un reporte de permisos
        /// </summary>
        /// <param name="codcli">cliente</param>
        /// <param name="m">mes</param>
        /// <param name="y">anio</param>
        /// <returns></returns>
        public async static Task<byte[]> reportePermisos(int codcli, int m, int y)
        {
            API api = new API(local, token);
            Reporte rpt = new Reporte()
            {
                codcli = codcli,
                m = m,
                y = y
            };
            byte[] bytes;
            try
            {
                bytes = await Task.Run(() => api.download($"reportePermisos.pdf", rpt));
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }        
        public async static Task<byte[]> downloadInstalador()
        {
            API api = new API(local, token);
            byte[] bytes;
            try
            {
                Uri uri = new Uri(APIURL);
                bytes = await Task.Run(() => api.download(uri.Scheme + "://" + uri.Authority + "/app/setup.exe"));
            }
            catch (Exception)
            {
                return null;
            }
            return bytes;
        }

        /// <summary>
        /// Permite validar un usuario
        /// </summary>
        /// <param name="user">usuario</param>
        /// <param name="pass">password</param>
        /// <param name="codcli">codcli</param>
        /// <returns></returns>
        public static Usuario Login(string user, string pass, int codcli)
        {
            Credenciales cred = new Credenciales(user, pass, codcli);
            API<List<Usuario>> api = new API<List<Usuario>>(local, token);
            var t = Task.Run(() => api.post("login", cred));
            try
            {
                t.Wait();
                return t.Result[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite validar un usuario
        /// </summary>
        /// <param name="user">usuario</param>
        /// <param name="pass">password</param>        
        /// <returns></returns>
        public static Usuario Login(string user, string pass)
        {
            Credenciales cred = new Credenciales(user, pass);
            API<List<Usuario>> api = new API<List<Usuario>>(local, token);
            var t = Task.Run(() => api.post("login", cred));
            try
            {
                t.Wait();
                return t.Result[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private class Credenciales
        {
            public string user { get; set; }
            public string password { get; set; }
            public int codcli { get; set; }
            public Credenciales(string user, string password, int codcli)
            {
                this.user = user;
                this.password = password;
                this.codcli = codcli;
            }

            public Credenciales(string user, string password)
            {
                this.user = user;
                this.password = password;
            }
        }

        public enum ESTADO
        {
            ESPERA,
            APROBADO,
            RECHAZADO
        }
        private enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }                
        /// <summary>
        /// Convierte bites a un valor en base a su unidad
        /// </summary>
        /// <param name="value">valor en bites</param>
        /// <param name="unit">unidad a la que se dea convertir</param>
        /// <returns></returns>
        private double ToSize(Int64 value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));
        }
        /// <summary>
        /// Entidad de archivos adjuntos
        /// </summary>
        public class UploadState
        {
            public bool status { get; set; }
            public string message { get; set; }
            public UploadState()
            {

            }
        }
        
        /// <summary>
        /// Interfaz de consulta de reportes
        /// </summary>
        public class Reporte
        {
            public int codcli { get; set; }
            public int m { get; set; }
            public int y { get; set; }
        }
        /// <summary>
        /// Interfaz de consulta de tablas por filtro avanzado
        /// </summary>
        private class Filter
        {
            public string query { get; set; }
            public string fields { get; set; }
        }

        /// <summary>
        /// Resultado de filtro de contador
        /// </summary>
        public class Counter
        {
            public int count { get; set; }
        }

        /// <summary>
        /// Resultado de edicion en base de datos
        /// </summary>
        public class Result
        {
            public int fieldCount;
            public int affectedRows;
            public int insertId;
            public int serverStatus;
            public int warningCount;
            public string message;
            public bool protocol41;
            public int changedRows;
        }
    }
}
