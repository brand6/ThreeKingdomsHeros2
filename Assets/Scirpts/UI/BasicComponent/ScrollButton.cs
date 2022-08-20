using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour
{
	public Scrollbar scrollbar;
	public bool isAdd;

	//��������������İ�ťЧ��
	public void onButtonClick()
	{
		if (isAdd)
		{
			scrollbar.value += 0.5f * scrollbar.size;
			Mathf.Clamp(scrollbar.value, 0, 1);
		}
		else
		{
			scrollbar.value -= 0.5f * scrollbar.size;
			Mathf.Clamp(scrollbar.value, 0, 1);
		}
	}
}
