using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
    public Text btnText;
    public string btnName;
	public int btnIndex;
	protected bool mouseIn;

	public int BtnIndex { get => btnIndex; set => btnIndex = value; }

	private void Awake()
    {
		SetText(btnName);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && mouseIn)
		{
			SoundManager.Instance.PlaySound("ButtonClick");
		}
	}

	public void SetText(string text)
	{
		btnText.text = text;
	}


	public void MouseEnter()
	{
        btnText.color = Color.green;
		mouseIn = true;

	}

    public void MouseExit()
	{
        btnText.color = Color.white;
		mouseIn = false;

	}

	public void KingSelectBtnClick()
	{
		SelectKingManager.Instance.ShowKingInfo(btnIndex);
	}
}
