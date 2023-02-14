using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de GlobalV
/// </summary>
public static class GlobalV
{
    public static string URLBASE { get; set; }

    public static string URL(HttpRequest request)
    {
        if (request.Url.Port == 80)
            return request.Url.Host;
        else
            return request.Url.Authority;
    }
    public static string RemoveSpecialCharacters(this string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str)
        {            
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
            {
                sb.Append(c);
            }
            else if(c == ' ')
            {
                sb.Append("-");
            }
        }
        return sb.ToString();
    }

    public static string[] PAISES = {
       "Afganistán", "Albania", "Argelia", "Andorra", "Angola", "Antigua y Barbuda",
       "Argentina", "Armenia", "Australia", "Austria", "Azerbaiyán", "Bahamas",
       "Bangladés", "Barbados", "Baréin", "Bélgica", "Belice", "Benín", "Bielorrusia",
       "Birmania", "Bolivia", "Bosnia y Herzegovina", "Botsuana", "Brasil", "Brunéi",
       "Bulgaria", "Burkina Faso", "Burundi", "Bután", "Cabo Verde", "Camboya",
       "Camerún", "Canadá", "Catar", "Chad", "Chile", "China", "Chipre", "Colombia",
       "Comoras", "Corea del Norte", "Corea del Sur", "Costa de Marfil", "Costa Rica",
       "Croacia", "Cuba", "Dinamarca", "Dominica", "Ecuador", "Egipto", "El Salvador",
       "Emiratos Árabes Unidos", "Eritrea", "Eslovaquia", "Eslovenia", "España",
       "Estados Unidos", "Estonia", "Etiopía", "Filipinas", "Finlandia", "Fiyi",
       "Francia", "Gabón", "Gambia", "Georgia", "Alemania", "Ghana", "Grecia",
       "Granada", "Guatemala", "Guinea", "Guinea-Bisáu", "Guinea Ecuatorial", "Guyana",
       "Haití", "Honduras", "Hungría", "Islandia", "India", "Indonesia", "Irán",
       "Irak", "Irlanda", "Israel", "Italia", "Jamaica", "Japón", "Jordania", "Kazajistán",
       "Kenia", "Kirguistán", "Kiribati", "Kuwait", "Laos", "Lesoto", "Letonia", "Líbano",
       "Liberia", "Libia", "Liechtenstein", "Lituania", "Luxemburgo", "Macedonia", "Madagascar",
       "Malasia", "Malaui", "Maldivas", "Malí", "Malta", "Marruecos", "Mauricio", "Mauritania",
       "México", "Micronesia", "Moldavia", "Mónaco", "Mongolia", "Montenegro", "Mozambique" };

    public static string[,] PLAN =
    {
        {"Plan Startup", "4.99", "1" },
        {"Plan PYME", "9.99", "2"},
        {"Plan Premium", "99.9", "3" }
    };
}