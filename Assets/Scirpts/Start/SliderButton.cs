using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderButton : MonoBehaviour
{
	public Slider slider;
	public bool isAdd;

	public void onButtonClick()
	{
		if (isAdd)
		{
			slider.value += 0.1f;
			Mathf.Clamp(slider.value,0, 1);
		}
		else
		{
			slider.value -= 0.1f;
			Mathf.Clamp(slider.value, 0, 1);
		}
	}
}
