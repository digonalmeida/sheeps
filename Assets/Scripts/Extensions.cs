using System;

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
}