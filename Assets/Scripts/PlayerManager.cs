using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //static to can access by other scripts
    public static bool gameOver; // gameover (true ==> player hits) (false == player succes)
    public GameObject gameOverPanel; // the panel which appear when player hits any obstacle 
    public static bool isGameStarted; // tell us if the game started or not
    public GameObject StartingText;
    public static int numberOfCoins; // variable or number of coins
    public Text CoinsText;
    void Start()
    {
        Time.timeScale = 1; // to enable the player to start playing after clicking replay
        gameOver = false; // initial state of gameover
        isGameStarted = false; // to show the text (TAP TO START) in the begin of game
        numberOfCoins = 0; // initial value of coins that player not hit any coin
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true); //it approaved when player hits any obstacle
            Time.timeScale = 0;
        }
        CoinsText.text = "Coins:" + numberOfCoins; // to show a text of total number of coins the player collects
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) // to start the game when player press on tap
        {
            isGameStarted = true; // if tap is true, game will start
            Destroy(StartingText); // to delete (TAP TO START) text after starting the game
        }
        // while(numberOfCoins <= 100)
        // {
            if (numberOfCoins == 35)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        // }
       
    }
}
