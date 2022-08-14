using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingBtn : MonoBehaviour
{
    public Text t;
	private int btnIndex;

	public int BtnIndex { get => btnIndex; set => btnIndex = value; }


	public void SetText(string str)
	{
		t.text = str;
	}

	public void OnKingSelect()
	{
		SelectKingManager.Instance.ShowKingInfo(btnIndex);
	}
}
