using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace Runner
{

    public class UIManager : MonoBehaviour
    {
        [Space]
        [Header("UI Variables")]
        [SerializeField] private GameObject Tap2Play;
        [SerializeField] private GameObject LevelFailed;
        [SerializeField] private GameObject LevelComplated;
        private void Start()
        {
            GameManager.LevelStarted += OnLevelStarted;
            GameManager.LevelFailed += OnLevelFailed;
            GameManager.LevelFinished += OnLevelEnded;
        }


        #region Event Methods
        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void OnLevelStarted()
        {
            Tap2Play.SetActive(false);
        }
        private void OnLevelFailed()
        {
            LevelFailed.SetActive(true);
        }
        private void OnLevelEnded()
        {
            LevelComplated.SetActive(true);
        }

        #endregion
    }
}
