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
		string objStr = JsonUtility.ToJson(obj);
		SaveJsonString(objStr, folderName, fileName);
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
		return (dataStr is null) ? default(T) : JsonMapper.ToObject<T>(dataStr);
	}

	/// <summary>
	/// ��LitJson������洢��json�ļ�
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="obj"></param>
	/// <param name="folderName"></param>
	/// <param name="fileName"></param>
	public static void SaveDataByLitJson<T>(T obj, string folderName, string fileName)
	{
		string dataStr = JsonMapper.ToJson(obj);
		SaveJsonString(dataStr, folderName, fileName);
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
		if (folderName is null)
		{
			filePath = Path.Combine(filePath, fileName + ".json");
		}
		else 
		{ 
			filePath = Path.Combine(filePath, folderName, fileName + ".json"); 
		}

		if (!File.Exists(filePath)) return null;
		return File.ReadAllText(filePath);
	}

	/// <summary>
	/// �洢json�ļ�
	/// </summary>
	/// <param name="str"></param>
	static void SaveJsonString(string objStr, string folderName, string fileName)
    {
		string path = Path.Combine(savePath, folderName, fileName + ".json");
		string directory = Path.GetDirectoryName(path);
		if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
		File.WriteAllText(path, objStr);
	}

}
