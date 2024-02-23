using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public Animator pauseTransition;

    public float animationTime = 2f;

    // Sets pause to always be false on game start
    void Awake()
    {
        isPaused = false;
    }

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
        Debug.Log("Resuming game...");

        StartCoroutine(UnpauseGame());

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Debug.Log("Pausing game...");

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
        yield return new WaitForSeconds(animationTime);
        // Do stuff
        pauseMenuUI.SetActive(false);
    }
}
