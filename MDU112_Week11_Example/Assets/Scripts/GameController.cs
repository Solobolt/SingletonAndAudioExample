using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public UIController uiController;
	public AudioController audioController;
    public PlayerController playerController;

    private int coinsRemaining;
    public float timeRemaining = 15f;

    private bool gameOver = false;

    public void AddCoin()
    {
        //The coin has notified us that we've added a new coin
        coinsRemaining++;
        uiController.coinCounter.SetValue(coinsRemaining);
    }

    public void CollectCoin()
    {
        //The coin has notified us that we've collected a coin
        coinsRemaining--;
        uiController.coinCounter.SetValue(coinsRemaining);
		audioController.CollectCoin ();

        if (coinsRemaining == 0)
        {//no coins remaining, we've won the game
            EndGame(true);
        }
    }

    void EndGame(bool didWin)
    {
        if (!gameOver)
        { //we want to make sure we only every process game over once
            gameOver = true;

            //make sure the player can't move anymore
            playerController.enableInput = false;

            //Show the game over screen
            uiController.gameOver.Show(didWin);
        }
    }

    void UpdateGameTimer()
    {
        if (gameOver)
        {
            return; //don't update the timer once the game is over
        }

        //Decrement the time
        timeRemaining -= Time.deltaTime;

        //Check if we've lost the game, and end the game if we have
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame(false);
        }

        //Update the UI with the new time
        uiController.timer.SetValue(timeRemaining);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Update the game timer, and end the game if we run out of time
        UpdateGameTimer();
	}
}
