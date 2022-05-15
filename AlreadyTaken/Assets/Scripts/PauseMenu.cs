using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        isGamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }   
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void saveGame()
    {
        Debug.Log("Saving game...");
    }

    public void quitGame()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevel(0));
        Debug.Log("Quitting game...");
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }

}
