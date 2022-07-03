using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextColor : MonoBehaviour
{
    public Text btnText;
    public string btnName;

    void Awake()
    {
        btnText.text = btnName;
    }

	public void MouseEnter()
	{
        btnText.color = Color.green;
    }

    public void MouseExit()
	{
        btnText.color = Color.white;
    }
}
