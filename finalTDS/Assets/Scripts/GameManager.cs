using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public int ratHealth = 0;
}

