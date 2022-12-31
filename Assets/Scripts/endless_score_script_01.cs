using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class endless_score_script_01 : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //FUNCTION THAT TESTS TO SEE IF AN OBJECT HAS ENTERED THE TRIGGER AREA OF A COLLIDER//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IF THE OBJECT THAT HAS ENTERED THE TRIGGER AREA HAS AN "Enemy" TAG ASSIGNED THEN...
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Score Object: SCORE!");

            //FIND THE ENEDLESS_GAME_MANAGER SCRIPT AND RUN THE FUNCITON CALLED INCREASESCORE
            FindObjectOfType<endless_game_manager_01>().IncreaseScore();

        }
    }
}
