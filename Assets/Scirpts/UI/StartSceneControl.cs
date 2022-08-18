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
	/// ��ʼ����Ϸ
	/// </summary>
	public void NewGame()
	{
		LoadObj.SetActive(true);
		LoadObj.GetComponent<LoadScene>().LoadNewScene("SelectKing");

	}


	/// <summary>
	/// ������Ϸ
	/// </summary>
	public void ContinueGame()
	{

	}

	/// <summary>
	/// ����������
	/// </summary>
	public void VoiceSetting()
	{
		MenuEnable(UIObj.volumn);
		MenuDisable(UIObj.menu);

	}

	/// <summary>
	/// �������˵�
	/// </summary>
	public void BackToMain()
	{
		MenuEnable(UIObj.menu);
		MenuDisable(UIObj.volumn);
	}

	/// <summary>
	/// �뿪��Ϸ
	/// </summary>
	public void QuitGame()
	{
		Application.Quit();
	}


	/// <summary>
	/// �ı���Ч����
	/// </summary>
	public void SoundVolumeChange(float volume)
	{
		SoundManager.Instance.SetSoundVolume(volume);
	}


	/// <summary>
	/// �ı���������
	/// </summary>
	public void MusicVolumeChange(float volume)
	{
		SoundManager.Instance.SetMusicVolume(volume);
	}

	/// <summary>
	/// ����˵�
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
	/// ���ز˵�
	/// </summary>
	/// <param name="target">falseΪ������������</param>
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
	/// �ӳ�����
	/// </summary>
	/// <param name="target">falseΪ������������</param>
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
