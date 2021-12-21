using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action GameStart;
    public event Action GameOver;

    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void OnGameStart()
    {
        GameStart.Invoke();
    }

    public void OnGameOver()
    {
        GameOver.Invoke();
    }
}