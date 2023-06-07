using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Singleton<T> : MonoBehaviourPunCallbacks where T:MonoBehaviourPunCallbacks
{
    private static T instance;
    public static T Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            else
            {
                Destroy(instance.gameObject);
            }
            return instance;
        }      
        
    }
}
