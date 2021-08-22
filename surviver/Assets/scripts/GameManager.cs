using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentScene;
    public GameObject GameOverPanel;
    public GameObject LevelFinishPanel;
    public KarakterManagerwithourCursor KarakterManager;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        GameOverState();
        LevelFinishState();
    }

    private void GameOverState()
    {
        if (KarakterManager.GameOver)
        {
            StartCoroutine(WaitGameOverPanel());
        }
    }

    private void LevelFinishState()
    {
        if (KarakterManager.LevelFinish)
        {
            StartCoroutine(WaitLevelFinishPanel());
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator WaitGameOverPanel()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
    }

    IEnumerator WaitLevelFinishPanel()
    {
        yield return new WaitForSeconds(1f);
        LevelFinishPanel.SetActive(true);
    }
}
