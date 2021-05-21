using System;
using UnityEngine;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        public static Action LevelStarted;
        public static Action LevelEnded;
        public static Action LevelFailed;


        private void Start()
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
            //TODO Start Running
        }


    }
}
