using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.Character
{
    public class CharacterManager : MonoBehaviour
    {
        #region Game Start
        private bool isGameStarted = false;
        #endregion
        [SerializeField] private InputControlller inputControlller;
        [SerializeField] private MovementController movementController;

        [SerializeField] private float speed = 1;
        public static Action characterStateChanged;

        [System.ComponentModel.DefaultValue(CharacterState.None)]
        private CharacterState characterState
        {

            get
            {
                return characterState;
            }
            set
            {
                characterState = value;
                characterStateChanged?.Invoke();
            }
        }
        private void Start()
        {
        }
        void Update()
        {
        }
        private void StartGame()
        {

        }

    }
}
