using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endless_player_movement_01 : MonoBehaviour
{

    //DEFINE A VARIABLE THAT WILL SET THE POSITION OF THE GAME OBJECT. VECTOR3 TYPE USED AS WE ARE USING MATH AND NOT AN ASSIGNMENT
    public Vector3 direction;

    //DEFINE A VARIABLE THAT WILL SET THE GRAVITY OR PULL ON THE GAME OBJECT
    public float gravity;
    //DEFINE A VARIABLE THAT WILL SET THE VERTICAL MOTION OF THE GAME OBJECT
    public float strength;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //MOVING THE CHARACTER//

        //IF THE KEY PRESSED DOWN IS THE SPACE BAR OR THE RIGHT MOUSE BUTTON THEN...
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //MULTIPLY THE Y VALUE OF THE DIRECTION VARIABLE BY THE STRENGTH VARIABLE.
            direction = Vector3.up * strength;
        }

        //APPLY GRAVITY TO THE Y VALUE OF direction BASED ON THE VALUE OF THE gravity VARIABLE
        direction.y += gravity * Time.deltaTime;

        //ADD DIRECTION MULTIPLIED BY Time.deltaTime TO THE POSITION OF THE GAME OBJECT. NOTE THAT THIS IS THE REASON WE USE A VECTOR3 FOR DIRECTION. THE TRANSFORM COMPONENT IS LOOKING FOR X,Y & Z. A VECTOR2 WILL NOT INCLUDE THE Z AND RESULT IN AN ERROR
        transform.position += direction * Time.deltaTime;

        //Time.deltaTime IS USED TO ENSURE THAT THE ACTION IS CONSISTENT REGARDLESS OF THE FRAME RATE. 

    }

    //FUNCTION THAT TESTS TO SEE IF AN OBJECT HAS ENTERED THE TRIGGER AREA OF A COLLIDER//

    void OnTriggerEnter2D(Collider2D collision)
    {
        //IF THE OBJECT THAT HAS ENTERED THE TRIGGER AREA HAS AN "Enemy" TAG ASSIGNED THEN...
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");

            //FIND THE "endless_game_manager_01" SCRIPT IN THE SCENE AND TRIGGER THE GameOver FUNCTION ASSOCIATE WITH IT
            FindObjectOfType<endless_game_manager_01>().GameOver();
        }
        //IF THE FIRST CONIDTION IS NOT TRUE THEN CHECK TO SEE IF THE OBJECT THAT HAS ENTERED THE TRIGGER AREA HAS A "Boundary" TAG ASSIGNED THEN...
        else if (collision.CompareTag("Boundary"))
        {
            Debug.Log("Game Over");

            // FIND THE "endless_game_manager_01" SCRIPT IN THE SCENE AND TRIGGER THE GameOver FUNCTION ASSOCIATE WITH IT
            FindObjectOfType<endless_game_manager_01>().GameOver();
        }
    }

}
