// Credited to Vlentful_Studios
// 8/11/2014
// 8/11/2014
// Attach to Main Camera

using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
	//Class References
	//public Ammo ammo;
	//public EconomySystem ecoSystem;
	public static SaveLoad saveLoad;
	
	void Awake ()
	{
		if (saveLoad == null)
		{
			saveLoad = this;
		}
		else if (saveLoad != this)
		{
			Destroy(gameObject);
		}
	}
	
	void Start ()
	{
		LoadGame();
	}
	
	public void SaveGame ()
	{
		//Main Save Information
		BinaryFormatter binaryFormat = new BinaryFormatter();
		string gameSaveDirectory = "C:/Vlentful Studios/ZomB Apoc/";
		string gameSaveName = "ZomB Apoc - Game Data.apoc";
		
		//Checks to make sure game directory exists
		if (!Directory.Exists(gameSaveDirectory))
		{
			Directory.CreateDirectory(gameSaveDirectory);
		}
		
		//More Save Information
		FileStream gameSave = File.Create(gameSaveDirectory + gameSaveName);
		GameData gameData = new GameData();
		
		//This is what gets saved
		/*gameData.amountOfAmmo = ammo.amountOfAmmo;
		gameData.amountOfAmmoClips = ammo.amountOfAmmoClips;
		
		gameData.amountOfZomBCash = ecoSystem.amountOfZomBCash;*/
		
		binaryFormat.Serialize(gameSave, gameData);
		gameSave.Close();
	}
	
	public void LoadGame()
	{
		//Main Load Information
		string gameSaveDirectory = "C:/Vlentful Studios/ZomB Apoc/";
		string gameSaveName = "ZomB Apoc - Game Data.apoc";
		
		//Checks to make sure save file exists
		if (File.Exists(gameSaveDirectory + gameSaveName))
		{
			BinaryFormatter binaryFormat = new BinaryFormatter();
			FileStream gameSave = File.Open(gameSaveDirectory + gameSaveName, FileMode.Open);
			GameData gameData = (GameData)binaryFormat.Deserialize(gameSave);
			
			gameSave.Close();
			
			/*ammo.amountOfAmmo = gameData.amountOfAmmo;
			ammo.amountOfAmmoClips = gameData.amountOfAmmoClips;
			
			ecoSystem.amountOfZomBCash = gameData.amountOfZomBCash;*/
		}
	}
}

[Serializable]
class GameData
{
	//Ammo Information
	public int amountOfAmmo = 10;
	public int amountOfAmmoClips = 5;
	
	//EconomySystem Information
	public int amountOfZomBCash = 0;
}




