using System.Collections;
using System.Collections.Generic;

public class GameManager : BaseSingletonMono<GameManager>
{
	protected override void Awake()
	{
		base.Awake();
		SoundManager.Instance.PlayBgMusic("Music01");
	}

	
}
