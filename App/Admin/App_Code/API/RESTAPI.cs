using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using WSControl;
using System.IO;

/// <summary>
/// Implementacion de api
/// </summary>
public class RESTAPI
{        
    private RESTAPI()
    {
        
    }
    /// <summary>
    /// Inserta nuevo departamento
    /// </summary>
    /// <param name="nombre">nombre departamento</param>
    public static void insertDepartamento(string nombre)
    {
        API<Departamentos> api = new API<Departamentos>();
        Departamentos dep = new Departamentos();
        dep.nombre = nombre;
        Task t = Task.Run(() => api.post("departamentos", dep));
        t.Wait();
    }
    /// <summary>
    /// Obtiene todos los departamentos
    /// </summary>
    /// <returns>Listado de departamentos</returns>
    public static List<Departamentos> listDepartamentos()
    {
        API<List<Departamentos>> api = new API<List<Departamentos>>();
        var t = Task.Run(() => api.get("departamentos"));
        return t.Result;
    }
    /// <summary>
    /// Actualiza un departamento
    /// </summary>
    /// <param name="coddpto">codigo departamento</param>
    /// <param name="nombre">nombre departamento</param>
    public static void updateDepartamento(int coddpto, string nombre)
    {
        API api = new API();
        Departamentos dep = new Departamentos();
        dep.nombre = nombre;
        Task t = Task.Run(() => api.put("departamentos/" + coddpto, dep));
        t.Wait();
    }
    /// <summary>
    /// Elimina un departamento
    /// </summary>
    /// <param name="coddpto">codigo departamento</param>
    public static void deleteDepartamento(int coddpto)
    {
        API api = new API();
        Task t = Task.Run(() => api.delete("departamentos/" + coddpto));
        t.Wait();
    }
    /// <summary>
    /// Obtiene un departamento por id
    /// </summary>
    /// <param name="coddpto">codigo departamento</param>
    /// <returns></returns>
    public static Departamentos getDepartamento(int coddpto)
    {
        API<Departamentos> api = new API<Departamentos>();
        var t = Task.Run(() => api.get("departamentos/" + coddpto));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Filtra una tabla en relacion a una condicion
    /// </summary>
    /// <param name="table">nombre de la tabla</param>
    /// <param name="cond">condicion</param>
    /// <returns></returns>
    public static List<object> filter(string table, string cond)
    {
        API<List<object>> api = new API<List<object>>();
        Filter f = new Filter();
        f.query = cond;
        var t = Task.Run(() => api.post("query", f));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Inserta un nuevo empleado
    /// </summary>
    /// <param name="empleado">nuevo empleado</param>
    public static void insertEmpleado(Empleados empleado)
    {
        API api = new API();
        var t = Task.Run(() => api.post("empleados", empleado));
        t.Wait();
    }
    /// <summary>
    /// Obtiene todos los empleados
    /// </summary>
    /// <returns>Listado de empleados</returns>
    public static List<Empleados> listEmpleados()
    {
        API<List<Empleados>> api = new API<List<Empleados>>();
        var t = Task.Run(() => api.get("empleados"));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Obtiene un empleado por su id
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    /// <returns></returns>
    public static Empleados getEmpleado(int codemp)
    {
        API<List<Empleados>> api = new API<List<Empleados>>();
        var t = Task.Run(() => api.get("empleados/" + codemp));
        t.Wait();
        return t.Result[0];
    }
    /// <summary>
    /// Actualiza un empleado especifico
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    /// <param name="empleado">objeto editado del empleado</param>
    public static void updateEmpleado(int codemp, Empleados empleado)
    {
        API api = new API();
        var t = Task.Run(() => api.put("empleados/" + codemp, empleado));
        t.Wait();        
    }
    /// <summary>
    /// Desactiva un empleado
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    public static void disableEmpleado(int codemp)
    {
        API api = new API();
        var t = Task.Run(() => api.delete("empleados/" + codemp));
        t.Wait();
    }
    /// <summary>
    /// Activa un empleado
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    public static void enableEmpleado(int codemp)
    {
        API api = new API();
        var t = Task.Run(() => api.get("empleados/" + codemp + "/enable"));
        t.Wait();
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
        API<List<Usuario>> api = new API<List<Usuario>>();
        var t = Task.Run(() => api.post("login", cred));
        try
        {
            t.Wait();
            return t.Result[0];
        }catch(Exception e)
        {
            return null;
        }
    }
    /// <summary>
    /// Obtiene los registros de un empleado
    /// </summary>
    /// <param name="codemp">codigo de empleado</param>
    /// <returns></returns>
    public static List<Registros> listRegistros(int codemp)
    {
        API<List<Registros>> api = new API<List<Registros>>();
        var t = Task.Run(() => api.get("registros/" + codemp));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Obtiene los registros de un empleado en una fecha especifica
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    /// <param name="dia"></param>
    /// <param name="mes"></param>
    /// <param name="anio"></param>
    /// <returns></returns>
    public static List<Registros> listRegistrosPorFecha(int codemp, int dia, int mes, int anio)
    {
        API<List<Registros>> api = new API<List<Registros>>();
        var t = Task.Run(() => api.get("registros/" + codemp + "/" + string.Format("{0}-{1}-{2}", dia,mes, anio)));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Obtiene todos los permisos
    /// </summary>
    /// <returns>Listado de permisos</returns>
    public static List<Permisos> listPermisos()
    {
        API<List<Permisos>> api = new API<List<Permisos>>();
        var t = Task.Run(() => api.get("permisos"));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Obtiene todos los permisos de un empleado
    /// </summary>
    /// <param name="codemp">codigo empleado</param>
    /// <returns></returns>
    public static List<Permisos> listPermisosDeEmpleado(int codemp)
    {
        API<List<Permisos>> api = new API<List<Permisos>>();
        var t = Task.Run(() => api.get("permisos/" + codemp));
        t.Wait();
        return t.Result;
    }
    /// <summary>
    /// Inserta un permiso nuevo
    /// </summary>
    /// <param name="permiso">nuevo permiso</param>
    public static void insertPermiso(Permisos permiso)
    {
        API api = new API();
        var t = Task.Run(() => api.post("permisos", permiso));
        t.Wait();
    }
    /// <summary>
    /// Actualiza un permiso
    /// </summary>
    /// <param name="codper">codigo del permiso</param>
    /// <param name="permiso">permiso editado</param>
    public static void updatePermiso(int codper, Permisos permiso)
    {
        API api = new API();
        var t = Task.Run(() => api.put("permisos/" + codper, permiso));
        t.Wait();
    }
    /// <summary>
    /// Cambia el estado de un permiso
    /// </summary>
    /// <param name="codper">codigo del permiso</param>
    /// <param name="estado">estado</param>
    public static void cambiarEstadoPermiso(int codper, ESTADO estado)
    {
        API api = new API();
        string c="E";
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
        var t = Task.Run(() => api.put("permisos/" + codper + "/" + c));
        t.Wait();
    }
    /// <summary>
    /// Elimina un permiso
    /// </summary>
    /// <param name="codper">codigo del permiso</param>
    public static void deletePermiso(int codper)
    {
        API api = new API();
        var t = Task.Run(() => api.delete("permisos/" + codper));
        t.Wait();
    }
    /// <summary>
    /// Permite subir un archivo adjunto al servidor
    /// </summary>
    /// <param name="codper">codigo del permiso</param>
    /// <param name="archivo">direccion del archivo</param>
    /// <returns></returns>
    public static UploadState uploadPermisoAdjunto(int codper, string archivo)
    {
        API<UploadState> api2 = new API<UploadState>();
        var task2 = Task.Run(() => api2.post("upload/" + codper, archivo, "attch"));
        task2.Wait();
        return task2.Result;
    }
    /// <summary>
    /// Permite descargar un archivo adjunto del servidor
    /// </summary>
    /// <param name="codper">codigo del permiso</param>
    /// <param name="archivo">direccion donde se guardara el archivo</param>
    /// <returns></returns>
    public async static Task<byte[]> downloadPermisoAdjunto(int codper, string archivo)
    {
        API api = new API();
        byte[] bytes;
        try
        {
            bytes = await Task.Run(() => api.download("download/" + codper));
        }
        catch (Exception)
        {            
            return null;
        }
        return bytes;
    }

    private class Credenciales
    {
        public string user { get; set; }
        public string password { get; set; }
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
    /// Entidad de Usuario
    /// </summary>
    public class Usuario
    {
        public int codemp { get; set; }
        public char estado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string departamento { get; set; }
        public bool admin { get; set; }
        public Usuario()
        {

        }
    }
    private class Filter
    {
        public string query { get; set; }
    }
}