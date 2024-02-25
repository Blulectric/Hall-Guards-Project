using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public Animator pauseTransition;

    public float animationTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Coroutine for animation purposes ^w^ -Liz
        StartCoroutine(UnpauseGame());
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    IEnumerator UnpauseGame()
    {
        // Trigger animation
        pauseTransition.SetTrigger("Unpaused");
        // Wait for animation to finish
        yield return new WaitForSecondsRealtime(animationTime);
        // Do stuff
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
