using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class InputControlller : MonoBehaviour
{
    public InputType inputType;
    [HideInInspector] public float DistanceX;
    public event Action OnMousePositionChanged;

    private bool isFirsttime = true;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 currentPosition = Vector3.zero;
    private bool IsInputTakeable = false;
    private void OnEnable()
    {
        GameManager.LevelFinished += OpenInputController;
        GameManager.LevelFailed += OpenInputController;

    }
    private void OnDisable()
    {
        GameManager.LevelFinished -= OpenInputController;
        GameManager.LevelFailed -= OpenInputController;
    }

    private void OpenInputController()
    {
        this.enabled = false;
    }
    private void Update()
    {
        TakeInput();
    }

    private void TakeInput()
    {

        switch (inputType)
        {
            case InputType.TapAndDrag:

                {
                    if (Input.GetMouseButtonDown(0))//butona butona basti
                    {
                        IsInputTakeable = true;
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
                    if (Vector3.Distance(startPosition, currentPosition) > .2f && IsInputTakeable)
                    {

                        OnMousePositionChanged?.Invoke();
                        DistanceX = (startPosition.x - currentPosition.x) / 100;
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        startPosition = currentPosition = Vector3.zero;
                        DistanceX = 0;
                        IsInputTakeable = false;
                    }
                    break;
                }
            case InputType.tapAndDragV2:
                {
                    if (IsInputTakeable)
                    {
                        var xDifference = Input.mousePosition.x - currentPosition.x;
                        var xPersentage = (100f * xDifference) / Screen.width;
                        DistanceX = xPersentage;
                        OnMousePositionChanged?.Invoke();
                    }
                    if (Input.GetMouseButton(0))
                    {
                        IsInputTakeable = true;
                        currentPosition = Input.mousePosition;
                        if (isFirsttime)
                        {
                            GameManager.LevelStarted?.Invoke();
                            isFirsttime = false;
                        }
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        IsInputTakeable = false;
                    }
                    break;
                }
            default:
                break;
        }
    }
}
