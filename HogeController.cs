using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogeController : MonoBehaviour
{
	CharacterDataManager characterDataManager;

    void Start()
    {
		characterDataManager = new CharacterDataManager();
    }

	/// <summary>
	/// 確認用
	/// </summary>
	public void ShowLogCharacters()
	{
		var characters = characterDataManager.characters;

		foreach(KeyValuePair<int, Character> character in characters)
		{
			Character c = character.Value;
			Debug.Log(
				"id:" + c.id + ", " + 
				"name:" + c.name + ", " + 
				"hp:" + c.hp + ", " + 
				"exp:" + c.exp
			);
		}

	}

	public void CreateCharacters()
	{
		// TODO 適当にInputフィールドとかから入れたりする
		characterDataManager.CreateCharacter("test", 100,100);
		Debug.Log("created");
	}

	public void ReduceHp()
	{
		characterDataManager.ReduceHp(1, 10);
		Debug.Log("reduced");
	}

	public void DeleteData()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("deleted.please restart");
	}
}
