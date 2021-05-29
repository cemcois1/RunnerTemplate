using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static Action LevelStarted;
    public static Action LevelFinished;
    public static Action LevelFailed;
    public static Action PrepareLevel;//todo load New level or 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        LevelStarted += OnLevelStarted;
        LevelStarted += StartRunning;
    }
    void OnLevelComplated()
    {

    }
    void OnLevelStarted()
    {
        //TODO Close StartButton
    }
    void StartRunning()
    {
        print("Running Started");
        //TODO Start Running
    }
}
