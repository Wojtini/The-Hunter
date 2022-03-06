
using System;

[Serializable]
public class PlayerStat
{
    public string name;
    public string description;
    public int value;

    public PlayerStat(string name, string description, int value = 0)
    {
        this.name = name;
        this.description = description;
        this.value = value;
    }
}