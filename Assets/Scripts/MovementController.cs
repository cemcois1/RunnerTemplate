﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner.Character
{
    public class MovementController : MonoBehaviour
    {
        [Space]
        [Header("Speed Variables")]
        [SerializeField] private float slideSpeed = 1;
        [SerializeField] private float forwardSpeed = 1;

        [Space]
        [Header("Bounce Limits")]
        [SerializeField] private float BounceRight = 0;
        [SerializeField] private float BounceLeft = 0;


        private Coroutine Runningcoroutine;
        private InputControlller inputControlller;
        private void Start()
        {
            inputControlller = GetComponent<InputControlller>();
            inputControlller.OnMousePositionChanged += MoveXAxis;
            GameManager.LevelStarted += Move;
            GameManager.LevelEnded += StopRunning;
            GameManager.LevelFailed += StopRunning;

        }
        public void Move()
        {
            Runningcoroutine = StartCoroutine(MoveCoroutine());
        }
        public IEnumerator MoveCoroutine()
        {
            while (true)
            {
                transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
                yield return null;
            }
        }
        private void MoveXAxis()
        {
            switch (inputControlller.inputType)
            {
                case InputType.TapAndDrag:
                    if (transform.position.x <= BounceRight && transform.position.x >= BounceLeft)
                    {
                        transform.position += inputControlller.DistanceX * Time.deltaTime * Vector3.left;
                    }
                    break;
                case InputType.tapAndDragV2:
                    transform.position += transform.right * Time.deltaTime * slideSpeed * inputControlller.DistanceX;
                    break;
                default:
                    break;
            }
            LimitPosition();
        }

        private void LimitPosition()
        {
            if (transform.position.x >= BounceRight)
                transform.position = new Vector3(BounceRight, transform.position.y, transform.position.z);
            if (transform.position.x <= BounceLeft)
                transform.position = new Vector3(BounceLeft, transform.position.y, transform.position.z);
        }

        private void StopRunning()
        {
            StopCoroutine(Runningcoroutine);
            print("Character Stopped");
        }


    }
}