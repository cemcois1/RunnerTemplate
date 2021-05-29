using Runner;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputControlller), typeof(MovementController), typeof(AnimationController))]
public class CharacterManager : MonoBehaviour
{
    #region Game Start
    private bool isGameStarted = false;
    #endregion
    private InputControlller inputControlller;
    private MovementController movementController;

    public static Action<CharacterState> CharacterStateChanged;
    private int i = 0;
    public CharacterState characterState
    {

        get
        {
            return characterState;
        }
        set
        {
            print(i + "Value :" + value);
            characterState = value;
            i++;
            //CharacterStateChanged?.Invoke(value);
        }
    }
    private void Start()
    {
        GameManager.LevelStarted += () => { print("Start Running"); };
        movementController = GetComponent<MovementController>();
        inputControlller = GetComponent<InputControlller>();
    }
}
