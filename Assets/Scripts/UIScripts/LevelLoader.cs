using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    
    // Scene Changer only for now, will need to update when adding extra mode (unless we can solve that so we don't have to go to another scene, but I digress) -Liz

    public void ChangeScene()
    {
        Debug.Log($"Changing to build index: {SceneManager.GetActiveScene().buildIndex + 1}");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        if (Time.timeScale == 0.0f) 
        {
            Time.timeScale = 1.0f;
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator StartExitGame()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Debug.Log("Game exited, quitting out now...");
        Application.Quit();
    }

    public void ExitGame()
    {
        StartCoroutine(StartExitGame());
    }

    public void MainMenu()
    {   
        StartCoroutine(LoadLevel(0));
    }
}
