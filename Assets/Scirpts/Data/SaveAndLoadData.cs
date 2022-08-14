using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadData
{
	/// <summary>
	/// ������ұ��������
	/// </summary>
	/// <param name="recordName"></param>
	/// <returns></returns>
	public static T LoadRecordData<T>(string recordName,string fileName)
	{
		return JsonTool.LoadDataByLitJson<T>(recordName, fileName, true);
	}

	/// <summary>
	/// ���ؾ籾����
	/// </summary>
	/// <param name="modName"></param>
	/// <returns></returns>
	public static T LoadModData<T>(string modName,string fileName)
	{
		return JsonTool.LoadDataByLitJson<T>(modName, fileName, false);
	}


	/// <summary>
	/// ������Ϸ����
	/// </summary>
	/// <param name="informations"></param>
	/// <param name="recordName"></param>
	public static void SaveData<T>(T obj,string recordName,string fileName)
	{
		JsonTool.SaveDataByJsonUtility(obj, recordName, fileName);
	}

}
