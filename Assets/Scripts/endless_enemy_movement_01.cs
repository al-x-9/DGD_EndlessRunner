using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endless_enemy_movement_01 : MonoBehaviour
{
    //DEFINE A VARIALBE THAT SETS THE SPEED OF THE GAME OBJECT
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        //ADD THE speed MULTIPLIED BY Time.deltaTime TO THE POSITION OF THE GAME OBJECT
        transform.position += Vector3.left * speed * Time.deltaTime;

        //Time.deltaTime IS USED TO ENSURE THAT THE ACTION IS CONSISTENT REGARDLESS OF THE FRAME RATE. 

    }
}
