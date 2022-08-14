using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : BaseManager<SoundManager>
{
	[HideInInspector]
	public float soundVolume = 1f; //��Ч������С
	public float musicVolume = 1f; //����������С

	private GameObject musicGO; //���ֶ���
	private AudioSource musicSource; //������Դ
	private string curMusic; //��ǰ���ŵ�����

	private Dictionary<string, GameObject> soundDict = new Dictionary<string, GameObject>();
	private GameObject sounds; //���������Ч�ĸ�����
	private GameObject soundGO; //��Ч����
	private AudioSource soundSource; //��Ч��Դ

	/// <summary>
	/// ��������
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
	/// ������Ч
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
	/// ��ȡ��Ч����,ͬ������Ч����ֻ�����һ��
	/// </summary>
	/// <param name="soundName"></param>
	/// <returns>��������</returns>
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
	/// �ص�������������������
	/// </summary>
	/// <param name="volume"></param>
	public void SetMusicVolume(float volume)
	{
		musicVolume = volume;
		musicGO.GetComponent<AudioSource>().volume = volume;
	}

	/// <summary>
	/// �ص�������������Ч����
	/// </summary>
	/// <param name="volume"></param>
	public void SetSoundVolume(float volume)
	{
		soundVolume = volume;
	}

	/// <summary>
	/// ��ȡ�������ã�Ĭ��ֵΪ1
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
	/// ������������
	/// </summary>
	/// <param name="soundVolume"></param>
	/// <param name="musicVolume"></param>
	public void saveVolume(float soundVolume,float musicVolume)
	{
		PlayerPrefs.SetFloat("soundVolume", soundVolume);
		PlayerPrefs.SetFloat("musicVolume", musicVolume);
	}
}
