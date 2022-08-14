using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKingManager:BaseSingletonMono<SelectKingManager>
{
    public GameObject content;
    public GameObject button;

    public King[] kings;

    private void Start()
	{
		Informations.Instance.LoadData("MOD01");
        kings = Informations.Instance.getKings();
        for (int i = 0; i < kings.Length; i++)
        {
            GameObject obj = Instantiate(button);
            ButtonHandle btnH = obj.GetComponent<ButtonHandle>();
            btnH.SetText(kings[i].name);
            btnH.BtnIndex = kings[i].index;
            obj.transform.SetParent(content.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(btnH.KingSelectBtnClick);
        }
    }



    public void ShowKingInfo(int kingIndex)
	{
        Debug.Log(kings[kingIndex].name);
	}
}
