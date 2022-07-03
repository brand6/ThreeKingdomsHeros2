using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : BaseManager<SoundManager>
{
	[HideInInspector]
	public float soundVolume = 1f;
	public float musicVolume = 1f;

	private GameObject musicGO;
	private AudioSource audioSource;

	private string curMusic;

	public void PlayBgMusic(string musicName)
	{
		if (musicName == curMusic) return;

		curMusic = musicName;
		if (musicGO == null)
		{
			musicGO = new GameObject("BGMusic");
			audioSource = musicGO.AddComponent<AudioSource>();
			audioSource.loop = true;
		}
		audioSource.clip = Resources.Load<AudioClip>(musicName);
		audioSource.Play();


		GameObject.DontDestroyOnLoad(musicGO);

		

	}
}
