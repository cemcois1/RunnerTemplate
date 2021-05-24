using System;
using UnityEngine;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        public static Action LevelStarted;
        public static Action LevelFinished;
        public static Action LevelFailed;


        private void Awake()
        {
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
}
