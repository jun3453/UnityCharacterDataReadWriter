using UnityEngine;

public class PlayerPrefsDataSerializer : IDataSerializer
{
	public void SaveInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}	

	public int LoadInt(string key, int defaultValue)
	{
		return PlayerPrefs.GetInt(key, defaultValue);
	}

	public void SaveString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public string LoadString(string key, string defaultValue)
	{
		return PlayerPrefs.GetString(key, defaultValue);
	}

	public void SaveFloat(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public float LoadFloat(string key, float defaultValue)
	{
		return PlayerPrefs.GetFloat(key, defaultValue);
	}
}
