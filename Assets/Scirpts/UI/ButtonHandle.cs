using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
    public Text btnText;
    public string btnName;

	private int btnIndex;
	protected bool mouseIn;
	protected bool isSelect = false;

	public int BtnIndex { get => btnIndex; set => btnIndex = value; }

	private void Awake()
    {
		SetText(btnName);
	}

	/// <summary>
	/// 在按钮上点击时播放点击音效
	/// </summary>
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && mouseIn)
		{
			SoundManager.Instance.PlaySound("ButtonClick");
		}
	}

	/// <summary>
	/// 更新按钮的文字
	/// </summary>
	/// <param name="text"></param>
	public void SetText(string text)
	{
		btnText.text = text;
	}

	/// <summary>
	/// 鼠标移入时变色
	/// </summary>
	public void MouseEnter()
	{
        btnText.color = Color.green;
		mouseIn = true;

	}

	/// <summary>
	/// 非选中状态时，移开鼠标恢复白色
	/// </summary>
    public void MouseExit()
	{
		if (!isSelect){
			btnText.color = Color.white;
			mouseIn = false;
		}
	}

	/// <summary>
	/// 选中按钮
	/// </summary>
	public void BtnSelect()
	{
		isSelect = true;
		btnText.color = Color.green;
	}

	/// <summary>
	/// 取消选中按钮
	/// </summary>
	public void BtnNotSelect()
	{
		isSelect = false;
		btnText.color = Color.white;
	}

	/// <summary>
	/// 更新君主信息
	/// </summary>
	public void KingSelectBtnClick()
	{
		SelectKingControl.Instance.ShowKingInfo(btnIndex);
	}
}
