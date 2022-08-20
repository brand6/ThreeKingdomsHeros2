using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKingControl:MonoBehaviour
{
    public Button backBtn;
    public Button confirmBtn;
    public GameObject LoadScene;
    public GameObject SelectKing;
    public GameObject SelectMod;
    public GameObject ModScrollContent;
    public GameObject buttonPrefab;
    
    private static SelectKingControl instance;
	public static SelectKingControl Instance { get => instance;}

	private void Awake()
	{
        instance = this;
        backBtn.onClick.AddListener(BackToStartScene);
        confirmBtn.onClick.AddListener(EnterAffairsScene);
        InitModList();
    }

    /// <summary>
    /// 初始化mod列表信息
    /// </summary>
    public void InitModList()
	{
        Mod[] mods = Informations.Instance.LoadModList();
        for (int i = 0; i < mods.Length; ++i)
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
        string modFolder = Informations.Instance.Mods[index].folder;
        Informations.Instance.LoadData(modFolder);
        LoadScene.GetComponent<LoadScene>().ShowNewUI(SelectKing);
        SelectMod.SetActive(false);
        ChangeBtnColor(ModScrollContent, index);
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
        Informations.Instance.PlayerKingIndex= KingListPanelManager.Instance.SelectKingIndex;
        LoadScene.SetActive(true);
        LoadScene.GetComponent<LoadScene>().LoadNewScene("InternalAffairs");
    }

    /// <summary>
    /// 改变选中按钮的颜色
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
