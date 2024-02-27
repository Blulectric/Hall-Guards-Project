using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script located in canvas > UIPanel > Bar > SlidingArea > ProgressBar
public class UI_heatLevelBar : MonoBehaviour
{
    public GameObject alertIcon;

    public GameObject heatBar;
    public Image heatBarFill;

    public Color above25;
    public Color above50;
    public Color above75;

    // Start is called before the first frame update
    void Start()
    {
        // here incase you forget to set alpha to 1
        above25.a = 1;
        above50.a = 1;
        above75.a = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (NPC_EnemySight.heatLevel == 0)
        {
            if (NPC_EnemyBehavior.attacking == true)
            {
                NPC_EnemyBehavior.attacking = false;
            }
        }

        if (NPC_EnemySight.heatLevel >= 100 && PLYR_Health.GameOver == false)
        {
            NPC_EnemyBehavior.attacking = true;
        }

        //get the clamped value for the heat bar
        if (NPC_EnemySight.inSightofAny)
        {
            NPC_EnemySight.heatLevel = Mathf.Clamp(NPC_EnemySight.heatLevel + (100 * Time.deltaTime), 0, 100);
        }
        else
        {
            NPC_EnemySight.heatLevel = Mathf.Clamp(NPC_EnemySight.heatLevel - (5 * Time.deltaTime), 0, 100);
        }

        // heatbar fill section
        // 0%
        if (NPC_EnemySight.heatLevel == 0)
        {
            heatBar.SetActive(false);
        } else 
        {
            heatBar.SetActive(true);
            float heatBarAmount = NPC_EnemySight.heatLevel / 100;
            
            //Debug.Log($"Heat Bar Amount: " + heatBarAmount);
            heatBarFill.fillAmount = heatBarAmount;

            if (heatBarAmount <= 0.25f) 
            {
                heatBarFill.color = above25;
            } else if (heatBarAmount <= 0.5f)
            {
                heatBarFill.color = above50;
            } else if (heatBarAmount <= 0.75f)
            {
                heatBarFill.color = above75;
            }
        }

        alertIcon.SetActive(NPC_EnemySight.inSightofAny);

    }
}
