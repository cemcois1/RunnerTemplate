using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Space]
    [Header("UI Variables")]
    [SerializeField] private GameObject Tap2Play;
    [SerializeField] private GameObject LevelFailed;
    [SerializeField] private GameObject LevelComplated;
    [SerializeField] private GameObject ProgressBar;
    private void OnEnable()
    {
        GameManager.PrepareLevel += PrepareLevelUI;
        GameManager.LevelStarted += OnLevelStarted;
        GameManager.LevelFailed += OnLevelFailed;
        GameManager.LevelFinished += OnLevelEnded;
    }
    private void OnDisable()
    {
        GameManager.PrepareLevel -= PrepareLevelUI;
        GameManager.LevelStarted -= OnLevelStarted;
        GameManager.LevelFailed -= OnLevelFailed;
        GameManager.LevelFinished -= OnLevelEnded;
    }
    private void PrepareLevelUI()
    {
        LevelComplated.SetActive(false);
        LevelFailed.SetActive(false);
        Tap2Play.SetActive(true);
        //TODO set progress bar
    }

    #region Event Methods
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.PrepareLevel?.Invoke();
    }
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.PrepareLevel?.Invoke();

    }
    public void OnLevelStarted()
    {
        Tap2Play.SetActive(false);
    }
    public void OnLevelFailed()
    {
        LevelFailed.SetActive(true);
    }
    public void OnLevelEnded()
    {
        LevelComplated.SetActive(true);
    }

    #endregion
}
