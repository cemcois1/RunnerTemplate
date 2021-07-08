using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Confetti : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.LevelFinished += PlayParticule;
    }

    private void PlayParticule()
    {
        GetComponent<ParticleSystem>().Play();
    }

    private void OnDisable()
    {
        GameManager.LevelFinished -= PlayParticule;
    }
}
