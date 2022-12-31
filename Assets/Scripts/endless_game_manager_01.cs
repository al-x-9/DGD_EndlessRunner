using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class endless_game_manager_01 : MonoBehaviour
{
    //PUBLIC VARIABLES//

    //USED IN THE GameOver FUNCTION TO DISPLAY THE GAME OVER SCREEN
    public GameObject gameOverScreen;

    public endless_game_over_01 gameOverScript;

    ////USED IN THE GameOver FUNCTION TO DEACTIVATE THE PLAYER OBJECT 
    public GameObject playerObject;
    //USED IN THE GameOver FUNCTION TO DEACTIVATE THE SCORING OBJECT
    public GameObject scoreObject;
    //USED THROUGHOUT THIS SCRIPT TO DISPLAY THE SCORE
    public Text scoreText;

    //PRIVATE VARIABLES//

    //USED THROUGHOUT THIS SCRIPT TO DETERMINE WHETHER THE GAME IS OVER OR NOT
    private bool gameOver = false;
    //USED THROUGHOUT THIS SCRIPT TO SET THE SCORE
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //SET THE SCORE TO ZERO
        score = 0;
        //DISPLAY THE SCORE USING THE scoreText TEXT OBJECT
        scoreText.text = score.ToString();   

    }

    // Update is called once per frame
    void Update()
    {
        //IF THE GAME IS OVER AND THE R KEY IS PRESSED THEN...
        if (gameOver==true && Input.GetKeyDown(KeyCode.R))
        {


            //LOAD THE SCENE CALLED SampleScene
            SceneManager.LoadScene("SampleScene");

            //SET THE gameOver VARIABLE TO FALSE
            gameOver = false;
 
        }
    }

    //THIS FUCNTION IS CALLED FROM endless_score_script_01
    public void IncreaseScore()
    {
        //Debug.Log("SCORING");

        //ADD 1 TO THE CURRENT SCORE VALUE
        score++;
        //DISPLAY THE SCORE USING THE scoreText TEXT OBJECT
        scoreText.text = score.ToString();
    }

    //THIS FUCNTION IS CALLED FROM endless_player_movement_01
    public void GameOver()
    {
        //Debug.Log("GAME OVER FUNCTION");

        //ACTIVATE THE GAME OVER SCREEN
        gameOverScreen.SetActive(true);

        gameOverScript.Setup(score);

        //DEACTIVATE THE PLAYER OBJECT
        playerObject.SetActive(false);

        //DEACTIVATE THE SCORE OBJECT
        scoreObject.SetActive(false);

        //SET THE gameOver VARIABLE TO TRUE. THIS WILL AFFECT WHETHER THE GAME WILL RESET WHEN THE "R" KEY IS PRESSED TO RESET THE GAME (SEE UPDATE ABOVE).
        gameOver = true;
    }
}
