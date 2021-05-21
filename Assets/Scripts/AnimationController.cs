﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Character
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] private float animationSpeed;
        private int isRuningHash = Animator.StringToHash("isRuning");
        private int AnimationspeedHash = Animator.StringToHash("Speed");
        void Start()
        {
            animator = GetComponent<Animator>();
            GameManager.LevelStarted += OnLevelStarted;
            CharacterManager.characterStateChanged += OnCharacterStateChanged;
        }

        private void OnLevelStarted()
        {
            animator.SetTrigger(isRuningHash);
            animator.SetFloat(AnimationspeedHash, animationSpeed);
        }

        private void OnCharacterStateChanged()
        {

        }
    }
}