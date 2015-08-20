using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class UIFlash : MonoBehaviour {

	private Image image;
	private Color startColor;
	private Color endColor;

	private float fadeDuration;
	private float fadeTimeRemaining;

	void Awake()
	{
		image =GetComponent<Image>();
	}

	public void Show (Color color, float duration)
	{
		startColor = color;
		endColor = new Color (
			startColor.r,
			startColor.g,
			startColor.b,
			0);
		fadeDuration = duration;
		fadeTimeRemaining = fadeDuration;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (fadeTimeRemaining > 0)
		{
			fadeTimeRemaining -= Time.deltaTime;

			if (fadeTimeRemaining < 0)
			{
				fadeTimeRemaining = 0;
			}

			float fadeNormal = 1f - (fadeTimeRemaining/fadeDuration);

			image.color = Color.Lerp (startColor,endColor,fadeNormal);
		}
	}
}
