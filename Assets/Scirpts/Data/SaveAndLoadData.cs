using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadData
{
	/// <summary>
	/// 加载玩家保存的数据
	/// </summary>
	/// <param name="recordName"></param>
	/// <returns></returns>
	public static T LoadRecordData<T>(string recordName,string fileName)
	{
		return JsonTool.LoadDataByLitJson<T>(recordName, fileName, true);
	}

	/// <summary>
	/// 加载剧本数据
	/// </summary>
	/// <param name="modName"></param>
	/// <returns></returns>
	public static T LoadModData<T>(string modName,string fileName)
	{
		return JsonTool.LoadDataByLitJson<T>(modName, fileName, false);
	}


	/// <summary>
	/// 保存游戏数据
	/// </summary>
	/// <param name="informations"></param>
	/// <param name="recordName"></param>
	public static void SaveData<T>(T obj,string recordName,string fileName)
	{
		JsonTool.SaveDataByJsonUtility(obj, recordName, fileName);
	}

}
