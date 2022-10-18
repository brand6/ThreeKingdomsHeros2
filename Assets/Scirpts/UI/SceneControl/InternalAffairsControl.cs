using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalAffairsControl : MonoBehaviour
{
	public Button ReturnBtn;
    public Button ReturnToStartBtn;
	public Button SaveBtn;
	public GameObject LoadSceneObj;

	public GameObject MainPanel;
	public GameObject SelectKingPanel;
	public GameObject GeneralsPanel;
	public GameObject GeneralListPanel;
	public GameObject GeneralPanel;

	public KingInfoPanelManager kingInfoUI;
	public Text Year;
	public Button MapBtn;
	public Button GeneralBtn;
	public Button DevelopBtn;
	public Button BuildBtn;
	public Button SearchBtn;
	public Button RecruteBtn;
	public Button OfficialBtn;
	public Button ItemBtn;
	public Button EndBtn;

	private Stack<GameObject> OpenUIStack = new Stack<GameObject>();

    private static InternalAffairsControl instance;

    public static InternalAffairsControl Instance { get => instance; set => instance = value; }

    private void Update()
	{
		if (Input.GetMouseButtonDown(1) && OpenUIStack.Count>0)
		{
			ReturnToMain();
		}
	}

	private void Awake()
	{
		instance = this;
		if (Informations.Instance.Kings == null)
		{
			Informations.Instance.LoadData("Record1",true);
			Informations.Instance.PlayerKingIndex = 0;
		}
		ReturnBtn.onClick.AddListener(ReturnToMain);
		ReturnToStartBtn.onClick.AddListener(BackToStartScene);
		SaveBtn.onClick.AddListener(OpenSaveUI);
		MapBtn.onClick.AddListener(OpenMap);
		GeneralBtn.onClick.AddListener(ShowGenerals);
		ShowKingInfo(Informations.Instance.PlayerKingIndex);
	}

	/// <summary>
	/// 根据选择更新君主信息
	/// </summary>
	/// <param name="kingIndex"></param>
	public void ShowKingInfo(int kingIndex)
	{
		King king = Informations.Instance.getKing(kingIndex);
		kingInfoUI.setKingHead(king.generalIdx + 1);
		kingInfoUI.SetKingName(king.name);
		kingInfoUI.SetCityNum(king.GetCitys().Count);
		kingInfoUI.SetMoney(king.Money);
		kingInfoUI.SetGeneralNum(king.Generals.Count);
		kingInfoUI.SetPopulation(king.Population);
		kingInfoUI.SetSoldierNum(king.SoldierNum);
	}

	/// <summary>
	/// 打开地图信息
	/// </summary>
	void OpenMap()
	{
		MainPanel.SetActive(false);
		LoadSceneObj.SetActive(true);
		ReturnBtn.gameObject.SetActive(true);
		OpenUIStack.Push(SelectKingPanel);
		LoadSceneObj.GetComponent<LoadScene>().ShowNewUI(SelectKingPanel);
	}

	/// <summary>
	/// 打开将军列表
	/// </summary>
	void ShowGenerals()
	{
		MainPanel.SetActive(false);
		GeneralPanel.SetActive(false);
		GeneralListPanel.SetActive(true);
		LoadSceneObj.SetActive(true);
		ReturnBtn.gameObject.SetActive(true);
		OpenUIStack.Push(GeneralsPanel);
		LoadSceneObj.GetComponent<LoadScene>().ShowNewUI(GeneralsPanel);
	}

	/// <summary>
	/// 打开将军详情
	/// </summary>
	public void ShowGeneral()
	{
		GeneralListPanel.SetActive(false);
		LoadSceneObj.SetActive(true);
		OpenUIStack.Push(GeneralPanel);
		LoadSceneObj.GetComponent<LoadScene>().ShowNewUI(GeneralPanel);
	}

	/// <summary>
	/// 回到主界面
	/// </summary>
	void ReturnToMain()
	{
		LoadSceneObj.SetActive(true);
		OpenUIStack.Pop().SetActive(false);
		ReturnBtn.gameObject.SetActive(false);
		LoadSceneObj.GetComponent<LoadScene>().ShowNewUI(MainPanel);
	}


	/// <summary>
	/// 回到开始界面
	/// </summary>
	public void BackToStartScene()
	{
		LoadSceneObj.SetActive(true);
		LoadSceneObj.GetComponent<LoadScene>().LoadNewScene("StartScene");
	}


	/// <summary>
	/// 打开存档界面
	/// </summary>
	public void OpenSaveUI()
	{
		Informations.Instance.SaveData("Record1");
	}

}
