using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターデータを統括するクラス
/// </summary>
public class CharacterDataManager
{
	const int DEFAULT_CHARACTER_ID = 1;

	public Dictionary<int, Character> characters { get; set; }
	CharacterReadWriter characterReadWriter = new CharacterReadWriter();

	public CharacterDataManager()
	{
		characters = characterReadWriter.LoadAll();
	}

	/// <summary>
	/// キャラクター作成
	/// </summary>
	/// <param name="name"></param>
	/// <param name="hp"></param>
	/// <param name="exp"></param>
	public void CreateCharacter(
		string name,
		int hp,
		int exp
	)
	{
		int id = characterReadWriter.GetNextMaxCharacterId();

		Debug.Log("nextMaxCharacterId" + id);

		Character character = new Character(id, name, hp, exp);
		characters.Add(id, character);

		characterReadWriter.Save(character);
	}

	/// <summary>
	/// IDからキャラクターのHPを減らす
	/// </summary>
	/// <param name="id"></param>
	public void ReduceHp(int id, int reduceValue)
	{
		var character = characters[id];

		character.ReduceHp(reduceValue);

		// FIXME
		// 毎回ここで更新走らせると重くなるので、
		// シーンの入れ替わりなどで一括保存するようにさせる
		characterReadWriter.Save(character);
	}
}
