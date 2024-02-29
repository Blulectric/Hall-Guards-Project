using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYR_Health : MonoBehaviour
{

    public int HP = 100;
    //public GameObject gameOverPanel;

    public GameObject hitScreenRed;

    [SerializeField]
    private GameOverScript goScript;

    public static bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
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
            // Disabled because I plan to set these for all game overs - Liz
            //Time.timeScale = 0f;
            //gameOverPanel.SetActive(true);
            goScript.EndGame(false);
        }

        StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {
        hitScreenRed.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        hitScreenRed.SetActive(false);

    }

}
