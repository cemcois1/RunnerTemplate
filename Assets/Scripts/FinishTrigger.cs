using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinishTrigger : MonoBehaviour
{
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
