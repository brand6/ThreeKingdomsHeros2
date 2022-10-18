using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralInfoPanelManager:MonoBehaviour
{
    public Image Head;
    public Text Name;
    public Text King;
    public Text Job;
    public Text Level;
    public Text Strength;
    public Text HP;
    public Text Intelligence;
    public Text MP;
    public Text Soldier;
    public Text EXP;
    public Text Equipment;

    public void setHead(int index)
	{
        Head.sprite = Resources.Load<Sprite>("Head/"+ index);
	}

    public void SetName(string name)
	{
        Name.text = name;

    }

    public void SetKing(string name)
    {
        King.text = name;

    }

    public void SetJob(string job)
    {
        Job.text = job;

    }

    public void SetLevel(int num)
    {
        Level.text = num.ToString();

    }

    public void SetStrength(int num)
    {
        Strength.text = num.ToString();

    }

    public void SetHP(string hp)
    {
        HP.text = hp;

    }

    public void SetIntelligence(int num)
    {
        Intelligence.text = num.ToString();

    }

    public void SetMP(string mp)
    {
        MP.text = mp;

    }

    public void SetEXP(string exp)
    {
        EXP.text = exp;

    }

    public void SetSoldierNum(string soldier)
    {
        Soldier.text = soldier;

    }

    public void SetWeapon(string weapon)
    {
        Equipment.text = weapon;
    }
}
