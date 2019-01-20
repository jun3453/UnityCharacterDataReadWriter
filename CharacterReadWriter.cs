using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターの読み込みと保存をする
/// </summary>
public class CharacterReadWriter
{
	const int ERROR_CHARACTER_ID = 0;
	const int MIN_CHARACTER_ID = 1;
	const string CHARACTER_MAX_ID_KEY = "character_max_id_key";

	int maxCharacterId { get; set; }
	IDataSerializer dataSerializer = new PlayerPrefsDataSerializer();

	public CharacterReadWriter()
	{
		maxCharacterId = LoadMaxCharacterId();
	}

	string GetIdKey(int id)
	{
		return "character_" + id + "_id";
	}

	string GetNameKey(int id)
	{
		return "character_" + id + "_name";
	}

	string GetHpKey(int id)
	{
		return "character_" + id + "_hp";
	}

	string GetExpKey(int id)
	{
		return "character_" + id + "_exp";
	}

	int LoadMaxCharacterId()
	{
		return dataSerializer.LoadInt(CHARACTER_MAX_ID_KEY, ERROR_CHARACTER_ID);
	}

	/// <summary>
	/// キャラクター最大値を更新する
	/// 最大値が現在より上回っていなければ更新しない
	/// 
	/// REVIEW ここのチェックは分けたほうがいいだろうか？
	/// </summary>
	/// <param name="id"></param>
	void UpdateMaxCharacterId(int id)
	{
		if (id > maxCharacterId)
		{
			maxCharacterId = id;
			dataSerializer.SaveInt(CHARACTER_MAX_ID_KEY, maxCharacterId);
		}	
	}
	public int GetNextMaxCharacterId()
	{
		return maxCharacterId + 1;
	}

	/// <summary>
	/// すべてロード
	/// </summary>
	/// <returns></returns>
	public Dictionary<int, Character> LoadAll()
	{
		var characters = new Dictionary<int, Character>();
		for (int i = maxCharacterId; i >= MIN_CHARACTER_ID ; i--)
		{
			var character = LoadById(i);
			characters.Add(i, character);
		}

		return characters;
	}

	/// <summary>
	/// ID指定でロード
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Character LoadById(int id)
	{
		int loadedId = dataSerializer.LoadInt(GetIdKey(id), ERROR_CHARACTER_ID);
		if (loadedId == ERROR_CHARACTER_ID)
		{
			// TODO 何かしらエラーハンドリングしたい
			Debug.Log("読み込みエラー: セーブされていないID");
		}

		string name = dataSerializer.LoadString(GetNameKey(id), "default");
		int hp = dataSerializer.LoadInt(GetHpKey(id), 0);
		int exp = dataSerializer.LoadInt(GetExpKey(id), 0);

		return new Character(id, name, hp, exp);
	}

	/// <summary>
	/// REVIEW 更新系と新規追加系は分けたほうがよいか
	/// </summary>
	/// <param name="character"></param>
	public void Save(Character character)
	{
		int id = character.id;
		dataSerializer.SaveInt(GetIdKey(id), id);
		dataSerializer.SaveString(GetNameKey(id), character.name);
		dataSerializer.SaveInt(GetHpKey(id), character.hp);
		dataSerializer.SaveInt(GetExpKey(id), character.exp);

		UpdateMaxCharacterId(id);
	}

	// TODO 一括保存 未実装
	// public void SaveAll(Dictionary<int, Character> charcters)
}
