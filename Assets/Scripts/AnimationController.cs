using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animationSpeed;
    private int isRuningHash = Animator.StringToHash("isRuning");
    private int AnimationspeedHash = Animator.StringToHash("Speed");
    void Reset()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameManager.LevelStarted += OnLevelStarted;
        CharacterManager.CharacterStateChanged += OnCharacterStateChanged;
    }
    private void OnDisable()
    {
        GameManager.LevelStarted -= OnLevelStarted;
        CharacterManager.CharacterStateChanged -= OnCharacterStateChanged;
    }
    private void OnLevelStarted()
    {
        animator.SetTrigger(isRuningHash);
        animator.SetFloat(AnimationspeedHash, animationSpeed);
    }

    private void OnCharacterStateChanged(CharacterState State)
    {
        print("TODO CHaracter State Chaned");
    }

    #region Editor Methods
    /// <summary>
    /// For testing
    /// </summary>
    public void SetSpeed()
    {
        animator.SetTrigger(isRuningHash);
        animator.SetFloat(AnimationspeedHash, animationSpeed);
        print("SetSpeed");
    }
    #endregion
}
