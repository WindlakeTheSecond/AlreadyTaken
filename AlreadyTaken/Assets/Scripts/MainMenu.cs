using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool isOptions = false;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject levelLoader;

    public void PlayGame() {
        levelLoader.SetActive(true);
        StartCoroutine(LoadLevel(1));
        PlayerPrefs.DeleteAll();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOptions)
        {
             optionsMenu.SetActive(false);
             mainMenu.SetActive(true);
        }
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        isOptions = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
