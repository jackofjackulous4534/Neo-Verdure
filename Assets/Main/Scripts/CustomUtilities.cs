using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class CustomUtilities
{
    public static float GetAngleOf2DVect(Vector2 startPos, Vector2 targetPos)
    {
        Vector2 directonVect = targetPos - startPos;
        return Mathf.Atan2(directonVect.y, directonVect.x) * Mathf.Rad2Deg;
    }
    public static Vector3 GetVectorByAngleAndDistance(float distance, float angle)
    {
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * distance, Mathf.Sin(angle * Mathf.Deg2Rad) * distance, 0);
    }

    private static Vector2 collisionAverageNormal;
    public static Vector3 GetAverageCollisionNormal(Collision2D collision)
    {
        collisionAverageNormal = Vector2.zero;
        foreach (ContactPoint2D contact in collision.contacts)
        {
            collisionAverageNormal += contact.normal;
        }
        return collisionAverageNormal / collision.contactCount;
    }

    /// <summary>
    /// Takes in a start time and checks if the required time has elapsed
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="requiredTime"></param>
    /// <returns></returns>
    public static bool HasTimeElapsed(float startTime, float requiredTime)
    {
        if (Time.time - startTime > requiredTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static float Sign(float value)
    {
        if (value == 0)
            return 0;
        else if (value > 0)
            return 1;
        else
            return -1;
    }

    public static Vector3 GetMousePos()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldPosition.z = 0f;
        return worldPosition;
    }
}

public class WeakEvent<TEventArgs> //https://steven-giesel.com/blogPost/675b75fc-2c1b-43da-9ff8-42962ca8159b <--- Got it from here. Delegates elude me.
{
    private readonly List<WeakReference> _listeners = new List<WeakReference>();

    public void AddListener(EventHandler<TEventArgs> handler)
    {
        _listeners.Add(new WeakReference(handler));
    }

    public void RemoveListener(EventHandler<TEventArgs> handler)
    {
        _listeners.RemoveAll(wr => !wr.IsAlive || wr.Target.Equals(handler));
    }

    public void Raise(object sender, TEventArgs args)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            var weakReference = _listeners[i];
            if (weakReference.IsAlive)
            {
                ((EventHandler<TEventArgs>)weakReference.Target)?.Invoke(sender, args);
            }
            else
            {
                _listeners.RemoveAt(i);
            }
        }
    }
}

/* How to use:
public class Publisher
{
    private readonly WeakEvent<EventArgs> _event = new WeakEvent<EventArgs>();

    public event EventHandler<EventArgs> Event
    {
        add => _event.AddListener(value);
        remove => _event.RemoveListener(value);
    }

    public class CustomEventArgs : EventArgs //Args for the event
    {
        //vars...
        public CustomEventArgs(args...)
        {
            //vars...
        }
    }

    public void RaiseEvent()
    {
        _event.Raise(this, EventArgs.Empty);
    }
}

public class Subscriber 
{
    private void SubscribeToEvent()
    {
        publisherInstance.Event += EventFunc;
    }
    private void EventFunc(object sender, EventArgs args)
    {
        //Do stuf...
    }
*/