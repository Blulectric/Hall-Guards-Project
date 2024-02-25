using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    private int exitNumber = 42;

    // Used to make the game always be unpaused on main menu screen loading, to prevent pause errors -Liz
    void Awake()
    {
        PauseMenu.isPaused = false;
    }
    
    // Scene Changer only for now, will need to update when adding extra mode (unless we can solve that so we don't have to go to another scene, but I digress) -Liz

    public void ChangeScene()
    {
        Debug.Log($"Changing to build index: {SceneManager.GetActiveScene().buildIndex + 1}");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        // This needs to be WFSRealtime, otherwise you can't reset to timeScale 1 - Liz
        yield return new WaitForSecondsRealtime(transitionTime);

        if (Time.timeScale == 0.0f) 
        {
            Time.timeScale = 1f;
        }

        if (levelIndex == exitNumber) 
        {
            Debug.Log("Exit number passed, exiting game now...");
            Application.Quit();
        } else 
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    public void ExitGame()
    {
        StartCoroutine(LoadLevel(exitNumber));
    }

    public void MainMenu()
    {   
        StartCoroutine(LoadLevel(0));
    }
}
