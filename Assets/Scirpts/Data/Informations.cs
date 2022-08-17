using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Informations: BaseManager<Informations>
{
	private King[] kings;
	private City[] citys;
	private General[] generals;
	//private Equipment[] equipments;

	private static List<Magic> magics;


	/// <summary>
	/// 加载mod数据
	/// </summary>
	/// <param name="modName"></param>
	public void LoadData(string modName)
	{
		kings = SaveAndLoadData.LoadModData<King[]>(modName, "kings");
		citys = SaveAndLoadData.LoadModData<City[]>(modName, "citys");
		generals = SaveAndLoadData.LoadModData<General[]>(modName, "generals");
		//更新城市内的武将列表
		for(int i = 0; i < generals.Length; ++i)
		{
			for (int j = 0; j < citys.Length; ++j)
			{
				if (generals[i].city == citys[j].index)
				{
					citys[j].AddGeneral(generals[i]);
					break;
				}
			}
		}
		//更新君主的城市列表
		for (int i = 0; i < citys.Length; ++i)
		{
			for (int j = 0; j < kings.Length; ++j)
			{
				if (citys[i].king == kings[j].index)
				{
					kings[j].AddCity(citys[i]);
					break;
				}
			}
		}
	}


	public King[] getKings()
	{
		return kings;
	}

	public King getKing(int index)
	{
		for (int i = 0; i < kings.Length; ++i)
		{
			if (index == kings[i].index)
			{
				return kings[i];
			}
		}
		return null;
	}

	public City[] getCitys()
	{
		return citys;
	}

	public City getCity(int index)
	{
		for (int i = 0; i < citys.Length; ++i)
		{
			if (index == citys[i].index)
			{
				return citys[i];
			}
		}
		return null;
	}


	public General[] getGenerals()
	{
		return generals;
	}

	public General getGeneral(int index)
	{
		for (int i = 0; i < generals.Length; ++i)
		{
			if (index == generals[i].index)
			{
				return generals[i];
			}
		}
		return null;
	}

}
