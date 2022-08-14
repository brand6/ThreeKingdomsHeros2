using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseSingletonMono<GameManager>
{
	protected override void Awake()
	{
		base.Awake();
		SoundManager.Instance.PlayBgMusic("Music01");
		DontDestroyOnLoad(gameObject);
	}


}
