using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private const string KEY_TOTAL_COINS = "TOTAL_COINS";

    public UIController uiController;
	public AudioController audioController;
    public PlayerController playerController;

    private int coinsRemaining;
    public float timeRemaining = 15f;

	private bool hasStarted = false;
    private bool gameOver = false;
	public Color coinFlashColor;
	public float flashTime;

	void StartGame()
	{
		hasStarted = true;
		AudioController.Instance.StartMusic ();
		uiController.title.Hide ();
	}

	void Update()
	{
		if(!hasStarted&&playerController.hasInput)
		{
			StartGame ();
		}
		//Update the game timer, and end the game if we run out of time
		UpdateGameTimer();
	}

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
		uiController.flash.Show (coinFlashColor,flashTime);

        if (coinsRemaining == 0)
        {//no coins remaining, we've won the game
            EndGame(true);
        }

		int totalCoins = PlayerPrefs.GetInt (KEY_TOTAL_COINS, 0);
		totalCoins++;
		PlayerPrefs.SetInt (KEY_TOTAL_COINS, totalCoins);
		
		Debug.Log ("Total Coins Collected" + totalCoins);
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
		if(hasStarted)
		{
       		timeRemaining -= Time.deltaTime;
		}

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
	

}
