using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;


/// <summary>
/// XML序列化注意事项:
/// 类必须具有无参数构造函数才能被 XmlSerializer 序列化。
/// 只能序列化公共属性和字段。 属性必须具有公共访问器（get 和 set 方法）。
/// </summary>
public class XmlTool 
{
	static string savePath = Application.persistentDataPath + "/Save/";
	static string dataPath = Application.dataPath + "/Data/";

	public static T LoadScenarioData<T>(string modName)
	{
		string filePath = dataPath + modName + "/citys.xml";
		if (File.Exists(filePath))
		{
			using (StreamReader file = new StreamReader(filePath))
			{
				XmlSerializer xs = new XmlSerializer(typeof(T));
				T t =  (T)xs.Deserialize(file);
				return t;
			}
		}
		else
		{
			return default(T);
		}
	}
}
