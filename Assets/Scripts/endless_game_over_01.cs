using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class endless_game_over_01 : MonoBehaviour
{
    //DEFINE A VARIABLE THAT WILL SET VALUE OF THE SCORE TEXT IN THE GAME OVER SCREEN
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //CREATE A FUNCTION THAT REQUIRES A SCORE VARIABLE TO PASSED INTO IT.
    public void Setup(int score)
    {
        scoreText.text = "YOUR SCORE IS: " + score.ToString();
    }
}
