using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Object = System.Object;

public static class ServiceLocator
{
    private static HashSet<Object> _services = new HashSet<Object>();

    public static void AddService(Object service)
    {
        _services.Add(service);
    }
    public static void RemoveService(Object service)
    {
        _services.Remove(service);
    }

    public static bool GetService<T>(out T obj)
    {
        obj = (T)_services.FirstOrDefault(x => x is T);
        if (EqualityComparer<T>.Default.Equals(obj, default))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
