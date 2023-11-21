using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines instance
    {
        get
        {
            if (m_instanse == null)
            {
                var coroutineManager = new GameObject("[COROUTIONE MANAGER]");
                m_instanse = coroutineManager.AddComponent<Coroutines>();
                DontDestroyOnLoad(coroutineManager);
            }
            return m_instanse;
        }
    }

    private static Coroutines m_instanse;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            instance.StopCoroutine(routine);
        }
    }
}
