using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Informations: BaseManager<Informations>
{
	private Mod[] mods;
	private King[] kings;
	private City[] citys;
	private General[] generals;
	private int playerKingIndex;

	public int PlayerKingIndex { get => playerKingIndex; set => playerKingIndex = value; }
    public Mod[] Mods { get => mods; }
    public King[] Kings { get => kings; }
    public City[] Citys { get => citys;}
    public General[] Generals { get => generals; }


    /// <summary>
    /// 加载mod数据
    /// </summary>
    /// <param name="modName"></param>
    public void LoadData(string modFolder)
	{
		kings = SaveAndLoadData.LoadModData<King[]>(modFolder, "kings");
		citys = SaveAndLoadData.LoadModData<City[]>(modFolder, "citys");
		generals = SaveAndLoadData.LoadModData<General[]>(modFolder, "generals");
		//更新城市内的武将列表
		for(int i = 0; i < Generals.Length; ++i)
		{
			for (int j = 0; j < Citys.Length; ++j)
			{
				if (Generals[i].city == Citys[j].index)
				{
					Citys[j].AddGeneral(Generals[i]);
					break;
				}
			}
		}
		//更新君主的城市列表
		for (int i = 0; i < Citys.Length; ++i)
		{
			for (int j = 0; j < Kings.Length; ++j)
			{
				if (Citys[i].king == Kings[j].index)
				{
					Kings[j].AddCity(Citys[i]);
					break;
				}
			}
		}
	}

	/// <summary>
	/// 加载mod列表
	/// </summary>
	public Mod[] LoadModList()
    {
		mods = SaveAndLoadData.LoadModData<Mod[]>(null, "mods");
		return Mods;
	}


	public King getKing(int index)
	{
		for (int i = 0; i < Kings.Length; ++i)
		{
			if (index == Kings[i].index)
			{
				return Kings[i];
			}
		}
		return null;
	}

	public City getCity(int index)
	{
		for (int i = 0; i < Citys.Length; ++i)
		{
			if (index == Citys[i].index)
			{
				return Citys[i];
			}
		}
		return null;
	}

	public General getGeneral(int index)
	{
		for (int i = 0; i < Generals.Length; ++i)
		{
			if (index == Generals[i].index)
			{
				return Generals[i];
			}
		}
		return null;
	}

}
