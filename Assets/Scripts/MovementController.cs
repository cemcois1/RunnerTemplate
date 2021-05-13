using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner.Character
{
    public class MovementController : MonoBehaviour
    {

        [SerializeField] private float speed = 1;
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
                transform.position += Vector3.forward * Time.deltaTime * speed;
                yield return null;
            }
        }
        private void MoveXAxis()
        {
            if (transform.position.x <= BounceRight && transform.position.x >= BounceLeft)
            {
                transform.position += inputControlller.DistanceX * Time.deltaTime * Vector3.left;
            }
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