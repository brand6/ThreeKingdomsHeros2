using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneControl : MonoBehaviour
{
	public GameObject MenuObj;
	public Button StartBtn;
	public Button ContinueBtn;
	public Button VolumeBtn;
	public Button QuitBtn;
	public GameObject BackObj;
	public GameObject LoadObj;
	public GameObject VolumnObj;
	public Slider soundSlider;
	public Slider musicSlider;

	private Animator menuAnimator;
	private Animator volAnimator;
	private Animator backAnimator;

	private enum UIObj{menu,volumn};

	private void Awake()
	{
		menuAnimator = MenuObj.GetComponent<Animator>();
		volAnimator = VolumnObj.GetComponent<Animator>();
		backAnimator = BackObj.GetComponent<Animator>();
		SoundManager.Instance.getVolume();
		SoundManager.Instance.PlayBgMusic("Music01");

		StartBtn.onClick.AddListener(NewGame);
		ContinueBtn.onClick.AddListener(ContinueGame);
		VolumeBtn.onClick.AddListener(VoiceSetting);
		QuitBtn.onClick.AddListener(QuitGame);
		BackObj.GetComponent<Button>().onClick.AddListener(BackToMain);

		soundSlider.onValueChanged.AddListener(SoundVolumeChange);
		musicSlider.onValueChanged.AddListener(MusicVolumeChange);
	}

	/// <summary>
	/// 开始新游戏
	/// </summary>
	public void NewGame()
	{
		LoadObj.SetActive(true);
		LoadObj.GetComponent<LoadScene>().LoadNewScene("SelectKing");

	}


	/// <summary>
	/// 继续游戏
	/// </summary>
	public void ContinueGame()
	{

	}

	/// <summary>
	/// 打开音量设置
	/// </summary>
	public void VoiceSetting()
	{
		MenuEnable(UIObj.volumn);
		MenuDisable(UIObj.menu);

	}

	/// <summary>
	/// 返回主菜单
	/// </summary>
	public void BackToMain()
	{
		MenuEnable(UIObj.menu);
		MenuDisable(UIObj.volumn);
	}

	/// <summary>
	/// 离开游戏
	/// </summary>
	public void QuitGame()
	{
		Application.Quit();
	}


	/// <summary>
	/// 改变音效音量
	/// </summary>
	public void SoundVolumeChange(float volume)
	{
		SoundManager.Instance.SetSoundVolume(volume);
	}


	/// <summary>
	/// 改变音乐音量
	/// </summary>
	public void MusicVolumeChange(float volume)
	{
		SoundManager.Instance.SetMusicVolume(volume);
	}

	/// <summary>
	/// 激活菜单
	/// </summary>
	/// <param name="target"></param>
	private void MenuEnable(UIObj target)
	{
		switch (target)
		{
			case UIObj.menu:
				MenuObj.SetActive(true);
				menuAnimator.SetBool("isIn", true);
				break;
			case UIObj.volumn:
				soundSlider.value = SoundManager.Instance.soundVolume;
				musicSlider.value = SoundManager.Instance.musicVolume;
				VolumnObj.SetActive(true);
				BackObj.SetActive(true);
				volAnimator.SetBool("isIn", true);
				backAnimator.SetBool("isIn", true);
				break;
		}	
	}

	/// <summary>
	/// 隐藏菜单
	/// </summary>
	/// <param name="target">false为操作音量设置</param>
	private void MenuDisable(UIObj target)
	{
		switch (target)
		{
			case UIObj.menu:
				menuAnimator.SetBool("isIn", false);
				break;
			case UIObj.volumn:
				volAnimator.SetBool("isIn", false);
				backAnimator.SetBool("isIn", false);
				SoundManager.Instance.saveVolume(soundSlider.value,musicSlider.value);
				break;
		}
		StartCoroutine(DisableObj(target));
	}

	/// <summary>
	/// 延迟隐藏
	/// </summary>
	/// <param name="target">false为操作音量设置</param>
	/// <returns></returns>
	private IEnumerator DisableObj(UIObj target)
	{
		yield return new WaitForSeconds(1f);
		switch (target)
		{
			case UIObj.menu:
				MenuObj.SetActive(false);
				break;
			case UIObj.volumn:
				VolumnObj.SetActive(false);
				BackObj.SetActive(false);
				break;
		}
	} 

	
}
