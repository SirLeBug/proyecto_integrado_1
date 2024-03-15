using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionManager : MonoBehaviour
{
    void Awake()
    {
        Application.logMessageReceived += LogCaughtException;
        DontDestroyOnLoad(gameObject);
    }

    void LogCaughtException(string logText, string stackTrace, LogType logType)
    {
        if (logType == LogType.Exception)
        {
            Debug.Log("Juego Completado");
        }
    }
}
