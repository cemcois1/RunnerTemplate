using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{

    public class Confetti : MonoBehaviour
    {
        void Start()
        {
            GameManager.LevelFinished += Testmethod;
        }
        void Testmethod()
        {
            GetComponent<ParticleSystem>().Play();
        }
        void Update()
        {

        }
    }
}
