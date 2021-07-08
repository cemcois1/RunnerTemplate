using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    private Coroutine cameraFollow;
    private Vector3 offset;
    [SerializeField] private float smoothSpeed = 5;
    [Space]
    [Header("For Testing")]
    [SerializeField] private GameObject playerPosition;
    private void Reset()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {

        offset = playerPosition.transform.position - transform.position;
        cameraFollow = StartCoroutine(FollowPlayer());
    }
    private void OnEnable()
    {
        #region Events
        GameManager.LevelFinished += DontFollowPlayer;
        GameManager.LevelFailed += DontFollowPlayer;
        #endregion
    }
    private void OnDisable()
    {
        #region Events Disable
        GameManager.LevelFinished -= DontFollowPlayer;
        GameManager.LevelFailed -= DontFollowPlayer;
        #endregion
    }
    private IEnumerator FollowPlayer()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition.transform.position - offset, Time.deltaTime * smoothSpeed);
            yield return null;
        }
    }
    private void DontFollowPlayer()
    {
        StopCoroutine(cameraFollow);
    }

}

