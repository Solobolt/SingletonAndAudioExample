using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICoinCounter : MonoBehaviour {

    public Text value;

    public void SetValue(int coins)
    {
        value.text = coins.ToString();
    }

	// Use this for initialization
	void Start () {
	
	}
	
}
