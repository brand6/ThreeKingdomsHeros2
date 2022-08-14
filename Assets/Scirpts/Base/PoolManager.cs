using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : BaseManager<PoolManager>
{
	public Dictionary<string, List<GameObject>> poolDict = new Dictionary<string, List<GameObject>>();
	public Dictionary<string, GameObject> parentDict = new Dictionary<string, GameObject>();
	private GameObject pool;

	public GameObject GetObj(string name)
	{	
		GameObject obj;
		if (poolDict.ContainsKey(name))
		{
			if(poolDict[name].Count > 0)
			{
				obj = poolDict[name][0];
				poolDict[name].RemoveAt(0);
			}
			else
			{
				obj = CreateObj(name);
			}
		}
		else
		{
			CreateParent(name);
			obj = CreateObj(name);
		}
		obj.SetActive(true);
		return obj;
	}

	public void PushObj(string name,GameObject obj)
	{
		obj.SetActive(false);
		if (poolDict.ContainsKey(name))
		{
			poolDict[name].Add(obj);
		}
		else
		{
			poolDict.Add(name, new List<GameObject>() { obj });
			CreateParent(name);
			obj.transform.SetParent(parentDict[name].transform);
		}
	}

	private void CreateParent(string name)
	{
		if (pool == null) pool = new GameObject("pool");

		GameObject obj = new GameObject(name + "s");
		obj.transform.SetParent(pool.transform);
		parentDict.Add(name,obj);
		poolDict.Add(name, new List<GameObject>());
	}

	private GameObject CreateObj(string name)
	{
		GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(name));
		obj.name = name;
		obj.transform.SetParent(parentDict[name].transform);
		return obj;
	}
}


