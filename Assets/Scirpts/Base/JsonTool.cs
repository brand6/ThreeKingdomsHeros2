using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class JsonTool
{
	static string savePath = Application.persistentDataPath + "/Save/";
	static string dataPath = Application.dataPath + "/Data/";

	/// <summary>
	/// ��JsonUtility�������Ϊjson�ļ�
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="obj"></param>
	/// <param name="paths"></param>
	public static void SaveDataByJsonUtility<T>(T obj,string folderName,string fileName)
	{
		string path = Path.Combine(savePath, folderName, fileName + ".json");
		string directory = Path.GetDirectoryName(path);
		if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
		string objStr = JsonUtility.ToJson(obj);
		File.WriteAllText(path, objStr);
	}

	/// <summary>
	/// ��JsonUtility��json�ļ�תΪ����
	/// ���Զ����಻Ҫ�����޲ι���
	/// ���л���������������[System.Serializable]��
	/// ����ֱ�ӷ����л�Ϊ���ݼ��ϣ���װ��һ�����ڲ���
	/// ��֧���ֵ䣻
	/// �������л������Ե�˽�б�����
	/// �洢�ն���ʱ��洢Ĭ��ֵ��
	/// �ĵ������ʽ������ UTF-8��
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="paths"></param>
	/// <returns></returns>
	public static T LoadDataByJsonUtility<T>(string folderName,string fileName,bool isSave = false)
	{
		string dataStr = GetJsonString(folderName, fileName, isSave);
		return (dataStr is null)? default(T) : JsonUtility.FromJson<T>(dataStr);
	}

	/// <summary>
	/// ��LitJson��json�ļ�תΪ����
	/// �Զ�������Ҫ�޲ι��캯����
	/// ����Ҫ������ԣ�
	/// ����ֱ�Ӷ�ȡ���ݼ��ϣ�
	/// ֧���ֵ����ͣ�key��Ҫ���ַ�����
	/// �������л�˽�б�����
	/// �洢�ն���ʱ��洢null��
	/// �ĵ������ʽ������ UTF-8��
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="folderName"></param>
	/// <param name="fileName"></param>
	/// <param name="isSave"></param>
	/// <returns></returns>
	public static T LoadDataByLitJson<T>(string folderName, string fileName, bool isSave = false)
	{
		string dataStr = GetJsonString(folderName, fileName, isSave);

		T itemData= JsonMapper.ToObject<T>(dataStr);
		return itemData;
	}

	/// <summary>
	/// ��ȡjson�ļ���ȡ�ַ���
	/// </summary>
	/// <param name="folderName"></param>
	/// <param name="fileName"></param>
	/// <param name="isSave"></param>
	/// <returns></returns>
	static string GetJsonString(string folderName, string fileName, bool isSave = false)
	{
		string filePath = isSave ? savePath : dataPath;
		filePath = Path.Combine(filePath, folderName, fileName + ".json");
		if (!File.Exists(filePath)) return null;
		return File.ReadAllText(filePath);
	}

}
