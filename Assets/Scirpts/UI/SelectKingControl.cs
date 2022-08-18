using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKingControl:MonoBehaviour
{
    public Button backBtn;
    public Button confirmBtn;
    public GameObject LoadScene;
    public GameObject ScrollContent;
    public GameObject buttonPrefab;
    public GameObject map;
    public KingInfoPanelManager kingInfoUI;
    private int selectKingIndex;

    private static SelectKingControl instance;
	public static SelectKingControl Instance { get => instance;}

	private void Awake()
	{
        instance = this;
        backBtn.onClick.AddListener(BackToStartScene);
        confirmBtn.onClick.AddListener(EnterAffairsScene);

        //����mod����
        Informations.Instance.LoadData("MOD1");
        King[] kings = Informations.Instance.getKings();
        ShowKingInfo(kings[0].index);
        //����ѡ������µ��б�ť
        for (int i = 0; i < kings.Length; i++)
        {
            GameObject obj = Instantiate(buttonPrefab);
            ButtonHandle btnH = obj.GetComponent<ButtonHandle>();
            btnH.SetText(kings[i].name);
            btnH.BtnIndex = kings[i].index;
            obj.transform.SetParent(ScrollContent.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(btnH.KingSelectBtnClick);
        }
    }

    /// <summary>
    /// �ı�ѡ�о�����ť����ɫ
    /// </summary>
    public void ChangeBtnColor()
	{
        ButtonHandle[] btnHs = ScrollContent.GetComponentsInChildren<ButtonHandle>();
        for (int i = 0; i < btnHs.Length; ++i)
		{
            if (btnHs[i].BtnIndex == selectKingIndex)
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
    /// ����ѡ����¾�����Ϣ
    /// </summary>
    /// <param name="kingIndex"></param>
    public void ShowKingInfo(int kingIndex)
	{
        selectKingIndex = kingIndex;
        ChangeBtnColor();
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
    /// ����ѡ��ľ����ı��ͼС���ӵ���ɫ
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
    /// �ص���ʼ����
    /// </summary>
    public void BackToStartScene()
	{
        LoadScene.SetActive(true);
        LoadScene.GetComponent<LoadScene>().LoadNewScene("StartScene");
    }

    /// <summary>
    /// ������������
    /// </summary>
    public void EnterAffairsScene()
    {
        Informations.Instance.PlayerKingIndex= Informations.Instance.getKing(selectKingIndex).index;
        LoadScene.SetActive(true);
        LoadScene.GetComponent<LoadScene>().LoadNewScene("InternalAffairs");
    }
}
