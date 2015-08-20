using UnityEngine;
using System.Collections;

public class AudioController : SingletonBehaviour<AudioController> {

	public AudioSource sfx;
	public AudioSource BGM;

	public AudioClip[] coinCollect;
	public AudioClip[] bumpSound;
	public AudioClip[] music;

	protected override void SingletonAwake()
	{
		Debug.Log ("Starting Audio Controller");
	}

	protected override void SingletonDestroy()
	{
		Debug.Log ("Closing Audio Controller");
	}

	private static void Play(AudioSource source, AudioClip[] clips)
	{
		source.PlayOneShot (clips [Random.Range (0, clips.Length)]);
	}

	public void CollectCoin()
	{
		Play (sfx, coinCollect);
	}
	// Use this for initialization

	public void BumpSound()
	{
		Play (sfx,bumpSound);
	}

	public void StartMusic()
	{
		Play (BGM , music);
	}

	void Start () {
	
	}
}
