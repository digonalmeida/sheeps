using System;
using System.Collections;
using UnityEngine;

public static class Extensions
{
    public static void SafeInvoke(this Action action)
    {
        if (action != null) action.Invoke();
    }

    public static void SafeInvoke<T>(this Action<T> action, T obj)
    {
        if (action != null) action.Invoke(obj);
    }

    public static void SafeInvoke<T, U>(this Action<T, U> action, T obj, U obj2)
    {
        if (action != null) action.Invoke(obj, obj2);
    }

    public static IEnumerator WaitAndAct(this MonoBehaviour mono,float duration, Action action){
        float timer = 0f;
        while(timer<=duration)
        {
            timer+=Time.deltaTime;
            yield return null;
        }
        action.SafeInvoke();
    }
}