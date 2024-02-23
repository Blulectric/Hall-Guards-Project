using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYR_Health : MonoBehaviour
{

    public int HP = 100;
    public GameObject gameOverPanel;

    public static bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        HP = Mathf.Clamp(HP - (damage), 0, 100);
        if (HP <= 0)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            GameOver = true;
        }
    }
}
