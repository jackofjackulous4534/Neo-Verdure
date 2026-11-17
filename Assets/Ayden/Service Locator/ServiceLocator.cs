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
            Debug.Log("####################");
            Debug.Log(service.GetType());
            Debug.Log(typeof(T));

            if (service.GetType() is T)
            {
                Debug.Log("####################");
                Debug.Log("Found service");
                obj = (T)service;
                return true;
            }
        }
        Debug.Log("####################");
        Debug.Log("Failed to find service");
        return false;
    }
}
