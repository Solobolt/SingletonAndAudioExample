using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 input;

    //We want to be able to disable input when the game is over, this will tell the component to stop reading input
    public bool enableInput = true;

    public float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enableInput)
        {
            //Collect input in awake, and apply it in fixed update
            input = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));
        }
        else
        { //input is disabled, so just zero out the input
            input = Vector2.zero;
        }
        //We should never go passed a magnitude of 1 - that's when we're at the limit of our movement
        input = Vector2.ClampMagnitude(input, 1f);
	}

    void FixedUpdate()
    {
        //Tell the rigid body to move our position based on our input
        rb.MovePosition((Vector2)transform.position + (input * speed * Time.fixedDeltaTime));
    }

	void OnCollisionEnter2D()
	{
		AudioController.Instance.BumpSound ();
	}
}
