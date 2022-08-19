using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalAffairsControl : MonoBehaviour
{
    public Button ReturnToStartBtn;
	public GameObject LoadSeceneObj;
	public Text Year;

	private void Awake()
	{
		King king = Informations.Instance.getKing(Informations.Instance.PlayerKingIndex);
		Debug.Log(king.name);
		ReturnToStartBtn.onClick.AddListener(BackToStartScene);
	}

	/// <summary>
	/// 回到开始界面
	/// </summary>
	public void BackToStartScene()
	{
		LoadSeceneObj.SetActive(true);
		LoadSeceneObj.GetComponent<LoadScene>().LoadNewScene("StartScene");
	}

}
