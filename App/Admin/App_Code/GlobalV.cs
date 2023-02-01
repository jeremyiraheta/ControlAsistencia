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
}