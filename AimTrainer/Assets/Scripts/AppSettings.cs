using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppSettings : MonoBehaviour
{
    private static AppSettings _instance;
    public static AppSettings Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
