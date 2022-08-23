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
	/// 用JsonUtility将对象存为json文件
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
	/// 用JsonUtility将json文件转为对象；
	/// 对自定义类不要求有无参构造
	/// 序列化的类对象需加特性[System.Serializable]；
	/// 不能直接反序列化为数据集合，需装在一个类内部；
	/// 不支持字典；
	/// 可以序列化加特性的私有变量；
	/// 存储空对象时会存储默认值；
	/// 文档编码格式必须是 UTF-8；
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
	/// 用LitJson将json文件转为对象；
	/// 自定义类需要无参构造函数；
	/// 不需要需加特性；
	/// 可以直接读取数据集合；
	/// 支持字典类型，key需要是字符串；
	/// 不能序列化私有变量；
	/// 存储空对象时会存储null；
	/// 文档编码格式必须是 UTF-8；
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
	/// 用LitJson将对象存储到json文件
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
	/// 读取json文件获取字符串
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
	/// 存储json文件
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
