using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : BaseManager<SoundManager>
{
	[HideInInspector]
	public float soundVolume = 1f; //音效音量大小
	public float musicVolume = 1f; //音乐音量大小

	private GameObject musicGO; //音乐对象
	private AudioSource musicSource; //音乐资源
	private string curMusic; //当前播放的音乐

	private Dictionary<string, GameObject> soundDict = new Dictionary<string, GameObject>();
	private GameObject sounds; //存放所有音效的父对象
	private GameObject soundGO; //音效对象
	private AudioSource soundSource; //音效资源

	/// <summary>
	/// 播放音乐
	/// </summary>
	/// <param name="musicName"></param>
	public void PlayBgMusic(string musicName)
	{
		if (musicName == curMusic) return;

		curMusic = musicName;
		if (musicGO == null)
		{
			musicGO = new GameObject("BGMusic");
			musicSource = musicGO.AddComponent<AudioSource>();
			musicSource.volume = musicVolume;
			musicSource.loop = true;
		}
		musicSource.clip = Resources.Load<AudioClip>(musicName);
		musicSource.Play();
		Object.DontDestroyOnLoad(musicGO);
	}

	/// <summary>
	/// 播放音效
	/// </summary>
	/// <param name="soundName"></param>
	public void PlaySound(string soundName)
	{
		soundGO = GetSoundObj(soundName);
		soundSource = soundGO.GetComponent<AudioSource>();
		soundSource.volume = soundVolume;
		if (!soundSource.isPlaying) soundSource.Play();
	}


	/// <summary>
	/// 获取音效对象,同名的音效对象只会存在一个
	/// </summary>
	/// <param name="soundName"></param>
	/// <returns>声音对象</returns>
	private GameObject GetSoundObj(string soundName)
	{
		if (soundDict.ContainsKey(soundName)) return soundDict[soundName];
		else
		{
			if (sounds == null) sounds = new GameObject("sounds");

			GameObject soundObj = new GameObject(soundName);
			soundObj.transform.SetParent(sounds.transform);
			AudioSource soundSource = soundObj.AddComponent<AudioSource>();
			soundSource.clip = Resources.Load<AudioClip>(soundName);
			soundDict.Add(soundName, soundObj);
			return soundObj;
		}
	}

	/// <summary>
	/// 回调函数，设置音乐音量
	/// </summary>
	/// <param name="volume"></param>
	public void SetMusicVolume(float volume)
	{
		musicVolume = volume;
		musicGO.GetComponent<AudioSource>().volume = volume;
	}

	/// <summary>
	/// 回调函数，设置音效音量
	/// </summary>
	/// <param name="volume"></param>
	public void SetSoundVolume(float volume)
	{
		soundVolume = volume;
	}

	/// <summary>
	/// 获取音量设置，默认值为1
	/// </summary>
	public void getVolume()
	{
		if (PlayerPrefs.HasKey("soundVolume"))
		{
			soundVolume = PlayerPrefs.GetFloat("soundVolume");
		}
		if (PlayerPrefs.HasKey("musicVolume"))
		{
			musicVolume = PlayerPrefs.GetFloat("musicVolume");
		}
	}

	/// <summary>
	/// 保存音量设置
	/// </summary>
	/// <param name="soundVolume"></param>
	/// <param name="musicVolume"></param>
	public void saveVolume(float soundVolume,float musicVolume)
	{
		PlayerPrefs.SetFloat("soundVolume", soundVolume);
		PlayerPrefs.SetFloat("musicVolume", musicVolume);
	}
}
