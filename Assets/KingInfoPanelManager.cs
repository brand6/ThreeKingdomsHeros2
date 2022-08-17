using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingInfoPanelManager:MonoBehaviour
{
    public Image kingHead;
    public Text kingName;
    public Text CityNum;
    public Text Money;
    public Text GeneralNum;
    public Text Population;
    public Text Soldier;

    public void setKingHead(int index)
	{
        kingHead.sprite = Resources.Load<Sprite>("Head/"+ index);
	}

    public void SetKingName(string name)
	{
        kingName.text = name;

    }

    public void SetCityNum(int num)
    {
        CityNum.text = num.ToString();

    }

    public void SetMoney(int num)
    {
        Money.text = num.ToString();

    }

    public void SetGeneralNum(int num)
    {
        GeneralNum.text = num.ToString();

    }

    public void SetPopulation(int num)
    {
        Population.text = num.ToString();

    }

    public void SetSoldierNum(int num)
    {
        Soldier.text = num.ToString();

    }
}
