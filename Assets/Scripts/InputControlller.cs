using UnityEngine;
using System;
namespace Runner.Character
{
    public class InputControlller : MonoBehaviour
    {
        public float DistanceX;
        public Action OnMousePositionChanged;

        private bool isFirsttime = true;
        private Vector3 startPosition = Vector3.zero;
        private Vector3 currentPosition = Vector3.zero;
        private bool IsInputTakeable = true;
        private void Start()
        {
            GameManager.LevelEnded += () => this.enabled = false;
            GameManager.LevelFailed += () => this.enabled = false;
        }

        private void Update()
        {
            TakeInput();
        }
        private void TakeInput()
        {
            //GameManager.LevelStarted?.Invoke();
            if (IsInputTakeable)
            {
                if (Input.GetMouseButtonDown(0))//butona butona basti
                {
                    startPosition = Input.mousePosition;
                    if (isFirsttime)
                    {
                        GameManager.LevelStarted?.Invoke();
                        isFirsttime = false;
                    }
                }
                if (Input.GetMouseButton(0))//butona basiliyor
                {

                    currentPosition = Input.mousePosition;
                }
                if (Vector3.Distance(startPosition, currentPosition) > .2f)
                {
                    OnMousePositionChanged?.Invoke();
                    print("event Triggered");
                    DistanceX = (startPosition.x - currentPosition.x) / 100;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    startPosition = currentPosition = Vector3.zero;
                    DistanceX = 0;
                }
            }
        }
    }
}