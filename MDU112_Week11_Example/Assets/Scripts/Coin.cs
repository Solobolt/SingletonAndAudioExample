using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


	// Use this for initialization
	void Start () {
        //Notify the game controller that we've been spawned
        GameObject.FindObjectOfType<GameController>().AddCoin();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.attachedRigidbody != null)
        {
            //This is not the most memory efficient want to do this - we can do a much quicker check with tags, but this shows how owe can get
            //the component ouf of the game object we've hit
            PlayerController playerController = collider.GetComponent<PlayerController>();

            if (playerController != null)
            {
                //Collect the coin
                Collect();
            }
        }
    }

    private void Collect()
    {
        //Notify the game controller that we've collected a coin
        GameObject.FindObjectOfType<GameController>().CollectCoin();

        //Destroy this coin so it can't be collected again
        GameObject.Destroy(gameObject);
    }
}
