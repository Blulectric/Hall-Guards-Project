using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script located in canvas > UIPanel > Bar > SlidingArea > ProgressBar
public class UI_heatLevelBar : MonoBehaviour
{

    public GameObject alertIcon;

    // Start is called before the first frame update
    void Start()
    {
        
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

        //move heat bar
        GetComponent<RectTransform>().sizeDelta = new Vector2(NPC_EnemySight.heatLevel * 3f, 20);
        alertIcon.SetActive(NPC_EnemySight.inSightofAny);

    }
}
