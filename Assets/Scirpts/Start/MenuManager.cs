using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	private Animator animator;
	

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
	private void OnEnable()
	{
		animator.SetBool("isActive", true);
	}

	public void Disable()
	{
		animator.SetBool("isActive", false);
		StartCoroutine(DisableObj());
	}

	private IEnumerator DisableObj()
	{
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	} 

	public void VoiceSetting()
	{

	}
}
