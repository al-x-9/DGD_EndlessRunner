using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endless_enemy_destroyer_01 : MonoBehaviour
{
    //DEFINE A VARIALBE THAT SETS THE LIFETIME OF THE ENEMY
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DESTROY THE GAMEOBJECT THE SCRIPT IS ATTATCHED TO AT THE ASSIGNED TIME
        Destroy(gameObject, lifetime);
    }
}
