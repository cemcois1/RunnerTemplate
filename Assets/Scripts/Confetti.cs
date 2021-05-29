using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Confetti : MonoBehaviour
{
    void Start()
    {
        GameManager.LevelFinished += () => GetComponent<ParticleSystem>().Play();
    }
}
