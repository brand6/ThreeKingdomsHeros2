using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectKingManager:BaseSingletonMono<SelectKingManager>
{
    public GameObject content;
    public GameObject button;

    public King[] kings;

    private void Awake()
	{
		Informations.Instance.LoadData("MOD01");
        kings = Informations.Instance.getKings();
        for (int i = 0; i < kings.Length; i++)
        {
            GameObject obj = Instantiate(button);
            KingBtn btnH = obj.GetComponent<KingBtn>();
            btnH.SetText(kings[i].name);
            btnH.BtnIndex = kings[i].index;
            obj.transform.SetParent(content.transform);
        }
    }

    public void ShowKingInfo(int kingIndex)
	{
        Debug.Log(kings[kingIndex]);
	}
}
