using UnityEngine;
using System.Collections;

public class AudioController : SingletonBehaviour<AudioController> {

	public AudioSource sfx;

	public AudioClip[] coinCollect;
	public AudioClip[] bumpSound;

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
	void Start () {
	
	}
}
