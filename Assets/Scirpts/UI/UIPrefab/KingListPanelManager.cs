using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingListPanelManager : MonoBehaviour
{
    public GameObject map;
    public KingInfoPanelManager kingInfoUI;
    public GameObject KingScrollContent;
    public GameObject buttonPrefab;

    private int selectKingIndex;
    private static KingListPanelManager instance;
	public static KingListPanelManager Instance { get => instance; }
	public int SelectKingIndex { get => selectKingIndex; set => selectKingIndex = value; }

	private void OnEnable()
	{
        instance = this;
        InitKingList();
    }

	/// <summary>
	/// 初始化君主信息列表
	/// </summary>
	public void InitKingList()
	{
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
    /// 根据选择更新君主信息
    /// </summary>
    /// <param name="kingIndex"></param>
    public void ShowKingInfo(int kingIndex)
    {
        selectKingIndex = kingIndex;
        ChangeBtnColor(KingScrollContent, kingIndex);
        ChangeMapStatus(kingIndex);
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
    public void ChangeMapStatus(int selectKingIndex)
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
	/// 改变选中君主按钮的颜色
	/// </summary>
	public void ChangeBtnColor(GameObject ScrollContent, int index)
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
}
