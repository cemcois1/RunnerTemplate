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

        public static event Action characterStateChanged;

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
            movementController = GetComponent<MovementController>();
            inputControlller = GetComponent<InputControlller>();
        }
    }
}
