using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private GameObject Player;
    private PLYR_Health playerHP;

    //// Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPS Player");
        playerHP = Player.GetComponent<PLYR_Health>();
         StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(4f);

        Destroy(gameObject);

    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject==Player)
        {
            playerHP.takeDamage(5);
            Destroy(gameObject);
        } 
       
    }







    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
