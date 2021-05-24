using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.Character
{
    [RequireComponent(typeof(InputControlller), typeof(MovementController), typeof(AnimationController))]
    public class CharacterManager : MonoBehaviour
    {
        #region Game Start
        private bool isGameStarted = false;
        #endregion
        private InputControlller inputControlller;
        private MovementController movementController;

        public static event Action<CharacterState> CharacterStateChanged;

        [System.ComponentModel.DefaultValue(CharacterState.None)]
        public CharacterState characterState
        {

            get
            {
                return characterState;
            }
            set
            {
                print("Value :" + value);
                characterState = value;
                CharacterStateChanged(value);
            }
        }
        private void Start()
        {
            GameManager.LevelStarted += () => characterState = CharacterState.Running;
            movementController = GetComponent<MovementController>();
            inputControlller = GetComponent<InputControlller>();
        }
    }
}
