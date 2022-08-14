using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class King
{
	public int index;
	public string name;
	public int active;
	public int generalIdx;

}


public class City
{
	public int index;
	public string name;
	public int king;
	public int population;
	public int money;
	public int reservistMax;
	public int reservist;
	public int defense;
	public List<int> objects;
	public List<int> generals;
	public List<int> prisons;

	public int SoldiersNum
	{
		get
		{
			return 0;
		}
	}
}


public class General
{
	public int index;
	public int king = -1;
	public int city = -1;
	public int magic0;
	public int magic1;
	public int magic2;
	public int magic3;
	public int equipment;
	public int strength;
	public int intellect;
	public int experience;
	public int level;
	public int healthMax;
	public int healthCur;
	public int manaMax;
	public int manaCur;
	public int soldierMax;
	public int soldierCur;
	public int knightMax;
	public int knightCur;
	public int arms;
	public int armsCur;
	public int formation;
	public int formationCur;
	public int escape;
	public int active = 1;
	public int prisonerIdx = -1;
	public int loyalty = 100;
	public int job;

}


public class Magic
{
	public int sequence;
	public string name;
	public int mp;
	public int power;
	public int attack;
	public int script;
	public string attrib;
	public string title;
	public string note;
	public string active;
	public int type;
	public int time;
	public int titile;

}


public class Equipment
{
	public int type;
	public int data;
}


public class Army
{
	public int king = -1;
	public int cityFrom = -1;
	public int cityTo = -1;
	public int commander = -1;
	public int money = 0;

	public int state;
	public int direction;
	public bool isFlipped;
	public Vector3 pos;
	public float timeTick;

	public List<int> generals = new List<int>();
	public List<int> prisons = new List<int>();
}