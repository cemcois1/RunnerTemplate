using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private List<Transform> particules = new List<Transform>();
        [SerializeField] private GameObject camera;
        private void Start()
        {
            GameManager.LevelFinished += playParticules;
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            for (int i = 0; i < camera.transform.childCount; i++)
            {
                particules.Add(camera.transform.GetChild(i));
            }

            if (particules.Count == 0)
            {
                Debug.LogError("Finish Particules is Null");
            }


        }
        private void playParticules()
        {
            print("Hey Particules Played ^^");
            //foreach (Transform particle in particules)
            //{
            //    particle.gameObject.SetActive(true);
            //    print(particle + "is called");
            //}
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                print("Level Finished");
                GameManager.LevelFinished?.Invoke();
            }
        }
    }
}
