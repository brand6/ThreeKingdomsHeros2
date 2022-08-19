using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKingControl:MonoBehaviour
{
    public Button backBtn;
    public GameObject LoadScene;
    public GameObject SelectMod;
    public GameObject ModScrollContent;
    public GameObject SelectKing;
    public GameObject KingScrollContent;
    public GameObject buttonPrefab;
    public GameObject map;
    public Button confirmBtn;
    public KingInfoPanelManager kingInfoUI;
    
    private int selectKingIndex;
    private static SelectKingControl instance;
	public static SelectKingControl Instance { get => instance;}

	private void Awake()
	{
        instance = this;
        backBtn.onClick.AddListener(BackToStartScene);
        confirmBtn.onClick.AddListener(EnterAffairsScene);

        Mod[] mods = Informations.Instance.LoadModList();
        for(int i = 0; i < mods.Length; ++i)
        {
            GameObject obj = Instantiate(buttonPrefab);
            ButtonHandle btnH = obj.GetComponent<ButtonHandle>();
            btnH.SetText(mods[i].name);
            btnH.BtnIndex = i;
            obj.transform.SetParent(ModScrollContent.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(btnH.ModSelectBtnClick);
        }
    }

    /// <summary>
    /// 加载mod数据
    /// </summary>
    /// <param name="modIndex"></param>
    public void LoadModeData(int index)
    {
        LoadScene.GetComponent<LoadScene>().ShowNewUI(SelectKing);
        ChangeBtnColor(ModScrollContent, index);
        SelectMod.SetActive(false);
        string modFolder = Informations.Instance.Mods[index].folder;
        Informations.Instance.LoadData(modFolder);
        King[] kings = Informations.Instance.Kings;
        ShowKingInfo(kings[0].index);
        //创建选择君主下的列表按钮
        for (int i = 0; i < kings.Length; i++)
        {
            GameObject obj = Instantiate(buttonPrefab);
            ButtonHandle btnH = obj.GetComponent<ButtonHandle>();
            btnH.SetText(kings[i].name);
            btnH.BtnIndex = kings[i].index;
            obj.transform.SetParent(KingScrollContent.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(btnH.KingSelectBtnClick);
        }
    }

    /// <summary>
    /// 改变选中君主按钮的颜色
    /// </summary>
    public void ChangeBtnColor(GameObject ScrollContent,int index)
	{
        ButtonHandle[] btnHs = ScrollContent.GetComponentsInChildren<ButtonHandle>();
        for (int i = 0; i < btnHs.Length; ++i)
		{
            if (btnHs[i].BtnIndex == index)
			{
                btnHs[i].BtnSelect();
            }
			else
			{
                btnHs[i].BtnNotSelect();
            }

        }
    }

    /// <summary>
    /// 根据选择更新君主信息
    /// </summary>
    /// <param name="kingIndex"></param>
    public void ShowKingInfo(int kingIndex)
	{
        selectKingIndex = kingIndex;
        ChangeBtnColor(KingScrollContent, kingIndex);
        ChangeMapStatus();
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
    /// 根据选择的君主改变地图小格子的颜色
    /// </summary>
    /// <param name="kingIndex"></param>
    public void ChangeMapStatus()
	{
        King king = Informations.Instance.getKing(selectKingIndex);
        List<City> citys = king.GetCitys();
        foreach (Transform child in map.transform)
		{
            Image image = child.GetComponent<Image>();
            image.color = Color.grey;
            foreach (City city in citys)
			{
                if (child.name == "City (" + city.index + ")")
				{
                    image.color = new Color(1, 1, 1, 1);
                    break;
				}
            }
		}
	}

    /// <summary>
    /// 回到开始界面
    /// </summary>
    public void BackToStartScene()
	{
        if (SelectMod.activeInHierarchy)
        {
            LoadScene.SetActive(true);
            LoadScene.GetComponent<LoadScene>().LoadNewScene("StartScene");
        }        
        else
		{
            LoadScene.GetComponent<LoadScene>().ShowNewUI(SelectMod);
            SelectKing.SetActive(false);
        }
    }

    /// <summary>
    /// 进入内政界面
    /// </summary>
    public void EnterAffairsScene()
    {
        Informations.Instance.PlayerKingIndex= Informations.Instance.getKing(selectKingIndex).index;
        LoadScene.SetActive(true);
        LoadScene.GetComponent<LoadScene>().LoadNewScene("InternalAffairs");
    }
}
