using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	SpriteRenderer fadeRender;
	float fadeTime = 0.5f;
	private string sceneName;
	private GameObject UIObj;

	void Start()
    {
		fadeRender = gameObject.GetComponent<SpriteRenderer>();
	}

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
			if (sceneName != null) { SceneManager.LoadScene(sceneName); }
			else 
			{
				if (UIObj != null) { UIObj.SetActive(true); }
				gameObject.SetActive(false); 
			}
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


	/// <summary>
	/// 渐隐后显示新的UI内容
	/// </summary>
	/// <param name="obj"></param>
	public void ShowNewUI(GameObject obj)
    {
		fadeTime = 0.3f;
		UIObj = obj;
	}
}
