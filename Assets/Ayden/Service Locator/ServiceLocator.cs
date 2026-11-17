using UnityEngine;
using System.Collections.Generic;
using System;
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
        Debug.Log(_services);
        Debug.Log(_services.Count);
        obj = default(T);
        foreach (var service in _services)
        {
            if (service.GetType() is T)
            {
                Debug.Log("Found service");
                obj = (T)service;
                return true;
            }
        }
        return false;
    }
}
