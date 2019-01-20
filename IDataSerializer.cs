interface IDataSerializer{
	
	void SaveInt(string key, int value);
	int LoadInt(string key, int defaultValue);

	void SaveString(string key, string value);
	string LoadString(string key, string defaultValue);

	void SaveFloat(string key, float value);
	float LoadFloat(string key, float defaultValue);

	// TODO
	// SaveDictionary
	// SaveUInt
	// 等、色々と入れていきたい
}
