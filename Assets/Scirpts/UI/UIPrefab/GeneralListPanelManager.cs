using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralListPanelManager : MonoBehaviour
{
    public GeneralInfoPanelManager GeneralInfoUI;
    public GameObject GeneralScrollContent;
    public GameObject buttonPrefab;

    private int selectGeneralIndex;
    private static GeneralListPanelManager instance;
    public static GeneralListPanelManager Instance { get => instance; }
    public int SelectGeneralIndex { get => selectGeneralIndex; set => selectGeneralIndex = value; }

    private void OnEnable()
    {
        instance = this;
        InitGeneralList(Informations.Instance.PlayerKingIndex);
    }

    /// <summary>
    /// 初始化将军信息列表
    /// </summary>
    public void InitGeneralList(int kingIndex)
    {
        King selectKing = Informations.Instance.getKing(kingIndex);
        //创建选择君主下的列表按钮
        for (int i = 0; i < selectKing.Generals.Count; i++)
        {
            General general = selectKing.Generals[i];
            GameObject obj = Instantiate(buttonPrefab);
            ButtonHandle btnH = obj.GetComponent<ButtonHandle>();
            btnH.SetText(general.name);
            btnH.BtnIndex = general.index;
            obj.transform.SetParent(GeneralScrollContent.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(btnH.GeneralSelectBtnClick);
        }
    }


    /// <summary>
    /// 打开将军详细信息界面
    /// </summary>
    /// <param name="index"></param>
    public void ShowGeneralInfo(int index)
    {
        General general = Informations.Instance.getGeneral(index);
        GeneralInfoUI.setHead(general.head);
        GeneralInfoUI.SetName(general.name);
        GeneralInfoUI.SetKing(Informations.Instance.getKing(general.king).name);
        GeneralInfoUI.SetLevel(general.level);
        GeneralInfoUI.SetStrength(general.strength);
        GeneralInfoUI.SetIntelligence(general.intellect);
        GeneralInfoUI.SetSoldierNum(general.soldierCur.ToString() + "/" + general.soldierMax.ToString());
        GeneralInfoUI.SetHP(general.healthCur.ToString() + "/" + general.healthMax.ToString());
        GeneralInfoUI.SetMP(general.manaCur.ToString() + "/" + general.manaMax.ToString());
        GeneralInfoUI.SetEXP(general.experience.ToString());
        GeneralInfoUI.SetJob(general.job.ToString());
        GeneralInfoUI.SetWeapon(general.equipment.ToString());
        InternalAffairsControl.Instance.ShowGeneral();
    }
}
