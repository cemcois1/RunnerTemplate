using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{

    public class FinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.LevelEnded?.Invoke();
            }
        }
    }
}
