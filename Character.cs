public class Character
{
	// FIXME 本当はuintにしたい
	public int id { get; set; }
	public string name { get; set; }
	public int hp { get; set; }
	public int exp { get; set; }

	public Character(int id, string name, int hp, int exp)
	{
		this.id = id;
		this.name = name;
		this.hp = hp;
		this.exp = exp;
	}

	public void ReduceHp(int reduceValue)
	{
		hp -= reduceValue;
	}
}
