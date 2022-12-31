using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endless_spawn_02 : MonoBehaviour
{
    //DEFINE A VARIABLE FOR THE GAME OBJECT WE INTEND TO SPAWN
    public GameObject prefab;

    //DEFINE A VARIABLE FOR HOW OFTEN THE GAME OBJECT IS SPAWNED
    public float spawnRate;

    public float spawnSpeed;

    //DEFINE A VARIABLE FOR HOW OFTEN THE DIFFICULTY LEVEL CHANGES
    public float difficultyRate;

    //DEFINE A VARIABLE FOR THE MAXIMUM Y VALUE THE GAME OBJECT CAN SPAWN AT
    public float maxY;

    //DEFINE A VARIABLE FOR THE MINUMUM Y VALUE THE GAME OBJECT CAN SPAWN AT
    public float minY;
    
    //DEFINE A VARIABLE FOR A TIMER FOR THE SPAWNER
    private float spawnCounter;

    //DEFINE A VARIABLE FOR A TIMER FOR THE DIFFICULTY LEVEL
    private float difficultyCounter;

    //DEFINE A VARIABLE FOR THE SCRIPT CALLED ENDLESS_ENEMY_MOVEMENT_01
    endless_enemy_movement_01 eem01;


    // Start is called before the first frame update
    void Start()
    {
        //SET THE difficultyCounter EQUAL TO THE difficultyRate FOR OUR COUNTDOWN (SEE UPDATE FUNCTION)
        difficultyCounter = difficultyRate;

        //ASSIGN THE ENDLESS_ENEMY_MOVMENT_01 SCRIPT TO OUR EEM01 VARIABLE
        eem01 = prefab.GetComponent<endless_enemy_movement_01>();

        //MAKE A REFERENCE TO THE SPEED VARIABLE IN OUR ENDLESS_ENEMY_MOVEMENT_01 SCRIPT AND ASSIGN IT A VALUE
        eem01.speed = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //IF spawnCounter IS LESS THAN OR EQUAL TO ZERO THEN...
        if (spawnCounter <= 0)
        {
            //CREATE A CLONE OF OUR ENEMY(PREFAB) USING INSTATNTIATE FUNCTION. WE WANT TO ASSIGN THE CLONE TO A GAMEOBJECT SO THAT WE CAN ASSIGN IT A RANDOM POSITION IN THE GAME SPACE (BELOW).
            GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity);
            
            //SET THE Y POSTION OF THE CLONE TO A RANDOM NUMBER BETWEEN minY & maxY 
            enemy.transform.position += Vector3.up * Random.Range(minY, maxY);

            //RESET THE SPAWN COUNTER
            spawnCounter = spawnRate;       
        }
        //IF THE CONDITION ABOVE IS NOT TRUE THEN...
        else
        {
            //SUBTRACT Time.deltaTime FROM spawnCounter. SERVES AS A COUNTDOWN TIMER FOR THE SPAWN RATE.
            spawnCounter -= Time.deltaTime;
        }

        //SUBTRACT Time.deltaTime FROM difficultyCounter. SERVES AS A COUNTDOWN TIMER FOR THE DIFFICULTY LEVEL.
        difficultyCounter -= Time.deltaTime;

        //IF difficultyCounter IS LESS THAN OR EQUAL TO ZERO THEN...
        if (difficultyCounter <= 0)
        {
            //CHANGE spawnRate TO SPAWN GAME OBJECTS FASTER BY 0.25
            spawnRate = spawnRate - 0.25f;

            //SET A LIMIT TO THE SPAWN RATE SO THAT IT DOES NOT GO BELOW 0.75
            spawnRate = Mathf.Clamp(spawnRate, 0.75f, spawnRate);

            //CHANGE speed OF THE GAME OBJECTS BY 0.25 RESULTING IN FASTER MOVEMENT
            eem01.speed = eem01.speed + 0.25f;

            //RESET THE difficultyCounter
            difficultyCounter = difficultyRate;
        }

        //Debug.Log("The Spawn counter is: " + spawnCounter);
        //Debug.Log("The Difficulty counter is: " + difficultyCounter);
    }
}
