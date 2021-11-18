using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ViewBag
/// </summary>
public static class ViewBag
{
    private static Dictionary<string,object> vls;

    public static void Set(string key, object value)
    {
        if (vls == null) vls = new Dictionary<string, object>();
        if (!vls.ContainsKey(key))
            vls.Add(key, value);
        else
            vls[key] = value;
    }
    public static void Remove(string key)
    {
        if(vls != null) 
            vls.Remove(key);
    }
    public static void Clear()
    {
        if (vls != null)
            vls.Clear();
    }
    public static object Get(string key)
    {
        if (vls != null)
        {
            if (vls.ContainsKey(key))
                return vls[key];
            else
                return "";
        }
        else
            return "";
    }
    public static List<object> Values
    {
        get
        {
            if (vls != null)
                return vls.Values.ToList();
            else
                return null;
        }
    }
}