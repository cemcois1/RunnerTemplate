using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.Finish
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private List<Transform> particules = new List<Transform>();
        [SerializeField] private GameObject mainCamera;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (GameManager.LevelFinished != null)
                {
                    GameManager.LevelFinished.Invoke();
                }
            }
        }
    }
}
