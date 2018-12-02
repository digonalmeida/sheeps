using System;
using System.Collections;
using System.Collections.Generic;
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

    public static IEnumerator WaitAndAct(this MonoBehaviour mono, float duration, Action action)
    {
        float timer = 0f;
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        action.SafeInvoke();
    }

    public static List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = UnityEngine.Random.Range(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList; //return the new random list
    }
}