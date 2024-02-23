using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;

    private bool toggleMenu = false;

    void OnGUI()
    {

        if (!PLYR_Health.GameOver)
        {

            if (Event.current.Equals(Event.KeyboardEvent("escape")))
            {
                toggleMenu = !toggleMenu;
                if (toggleMenu)
                {
                    paused();
                }
                else
                {
                    unpaused();
                }
            }

        }

        //if (toggleMenu) //could select buttons with W S and space maybe 
        //{
        //    if (Event.current.Equals(Event.KeyboardEvent("space")))
        //    {
        //        Debug.Log("Select");
        //    }

        //    if (Event.current.Equals(Event.KeyboardEvent("w")))
        //    {
        //        Debug.Log("up");
        //    }

        //    if (Event.current.Equals(Event.KeyboardEvent("s")))
        //    {
        //        Debug.Log("down");
        //    }
        //}

    }


    void paused()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    void unpaused()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
//Application.LoadLevel(1);
