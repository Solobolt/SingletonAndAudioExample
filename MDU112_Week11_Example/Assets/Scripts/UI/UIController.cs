using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public UICoinCounter coinCounter;
    public UITimer timer;
    public UIGameOver gameOver;
	public UITitle title;
	public UIFlash flash;

    void Awake()
    {
        //The game over panel should be disabled on start
        //If we've been editing the game, and forgotten to disable it, this will make sure we always hide
        //the game over at the start of the game
        if (gameOver.gameObject.activeSelf)
        {
            gameOver.gameObject.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
	}
}
