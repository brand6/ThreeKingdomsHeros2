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
	/// �ڰ�ť�ϵ��ʱ���ŵ����Ч
	/// </summary>
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && mouseIn)
		{
			SoundManager.Instance.PlaySound("ButtonClick");
		}
	}

	/// <summary>
	/// ���°�ť������
	/// </summary>
	/// <param name="text"></param>
	public void SetText(string text)
	{
		btnText.text = text;
	}

	/// <summary>
	/// �������ʱ��ɫ
	/// </summary>
	public void MouseEnter()
	{
        btnText.color = Color.green;
		mouseIn = true;

	}

	/// <summary>
	/// ��ѡ��״̬ʱ���ƿ����ָ���ɫ
	/// </summary>
    public void MouseExit()
	{
		if (!isSelect){
			btnText.color = Color.white;
			mouseIn = false;
		}
	}

	/// <summary>
	/// ѡ�а�ť
	/// </summary>
	public void BtnSelect()
	{
		isSelect = true;
		btnText.color = Color.green;
	}

	/// <summary>
	/// ȡ��ѡ�а�ť
	/// </summary>
	public void BtnNotSelect()
	{
		isSelect = false;
		btnText.color = Color.white;
	}

	/// <summary>
	/// ���¾�����Ϣ
	/// </summary>
	public void KingSelectBtnClick()
	{
		SelectKingControl.Instance.ShowKingInfo(btnIndex);
	}
}
