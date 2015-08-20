using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameOver : MonoBehaviour {

    public Text title;

    public void Show(bool didWin)
    {
        if (didWin)
        {
            title.text = "You win!";
        }
        else
        {
            title.text = "You lose!";
        }

        //Enable the game object so the player can see it
        //this is disabled by default
        gameObject.SetActive(true);
    }

    public void OnClick_PlayAgain()
    {
        //Reload the current level
        Application.LoadLevel(Application.loadedLevel);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
