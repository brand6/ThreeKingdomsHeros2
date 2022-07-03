using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingletonMono<T> : MonoBehaviour where T:MonoBehaviour
{
	private static T instance;
	protected virtual void Awake()
	{
		instance = this as T;
	}
}
