using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;


/// <summary>
/// XML���л�ע������:
/// ���������޲������캯�����ܱ� XmlSerializer ���л���
/// ֻ�����л��������Ժ��ֶΡ� ���Ա�����й�����������get �� set ��������
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
