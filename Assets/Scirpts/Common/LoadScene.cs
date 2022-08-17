using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	SpriteRenderer fadeRender;
	float fadeTime = 0.5f;
	private string sceneName;
	// Start is called before the first frame update
	void Start()
    {
		fadeRender = gameObject.GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		if (fadeTime < 0.5f)
		{
			fadeTime += Time.deltaTime;
			fadeTime = Mathf.Clamp(fadeTime, 0f, 0.5f);
			fadeRender.color = new Color(0, 0, 0, fadeTime * 2);
		}
		else
		{
			SceneManager.LoadScene(sceneName);
		}
	}

	/// <summary>
	/// 渐隐后加载新场景
	/// </summary>
	/// <param name="_sceneName"></param>
	public void LoadNewScene(string _sceneName)
	{
		fadeTime = 0f;
		sceneName = _sceneName;
	}
}
