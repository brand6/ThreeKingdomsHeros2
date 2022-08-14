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


	public void LoadData(string modName)
	{
		kings = SaveAndLoadData.LoadModData<King[]>(modName, "kings");

	}


	public King[] getKings()
	{
		return kings;
	}

}
