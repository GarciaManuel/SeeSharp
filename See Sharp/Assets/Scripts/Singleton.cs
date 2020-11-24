using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool isShuttingDown;
    private static object lockObject = new object();


    public static T Instance
    {
        get
        {
            if (!isShuttingDown)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();
                        if (instance == null)
                        {
                            var singletonGameObject = new GameObject();
                            instance = singletonGameObject.AddComponent<T>();
                            singletonGameObject.name = $"{typeof(T).FullName} - Singleton";
                            DontDestroyOnLoad(singletonGameObject);
                        }
                    }
                    return instance;
                }
            }
            return null;

        }
    }
    private void OnApplicationQuit()
    {
        isShuttingDown = true;
    }
    private void OnDestroy()
    {
        isShuttingDown = true;
    }

}
