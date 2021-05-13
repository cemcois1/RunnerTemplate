using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{

    public class DeadTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.LevelFailed?.Invoke();
            }
        }
    }
}

