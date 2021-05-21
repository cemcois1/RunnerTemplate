using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{

    public class CameraFollow : MonoBehaviour
    {
        private Coroutine cameraFollow;
        private Vector3 offset;
        [SerializeField] private float smoothSpeed;
        private GameObject playerPosition;


        private void Start()
        {
            #region Events
            GameManager.LevelFinished += DontFollowPlayer;
            GameManager.LevelFailed += DontFollowPlayer;
            #endregion
            playerPosition = GameObject.FindGameObjectWithTag("Player");
            offset = playerPosition.transform.position - transform.position;
            cameraFollow = StartCoroutine(FollowPlayer());
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
}

