using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    private List<PlayerStat> statList = new List<PlayerStat>();
    [Header("General Info")]
    public int level = 1;
    public int experience = 0;
    public int requiredExperience = 100;
    public int freePoints = 0;
    [Header("DPS")]
    public PlayerStat strength = new PlayerStat("Strength","Generic Description");
    public PlayerStat dexterity = new PlayerStat("Dexterity", "Generic Description");
    [Header("Mobility and survival")]
    public PlayerStat endurance = new PlayerStat("Endurance", "Generic Description");
    [Header("Awerness")]
    public PlayerStat intelligence = new PlayerStat("Intelligence", "Generic Description");
    public PlayerStat perception = new PlayerStat("Perception", "Generic Description");
    [Header("Misc")]
    public PlayerStat charisma = new PlayerStat("Charisma", "Generic Description");
    public PlayerStat coldBlood = new PlayerStat("Cold Blood", "Generic Description");
    public PlayerStat luck = new PlayerStat("Luck", "Generic Description");



    private void Start()
    {
        instance = this;
        generateList();
    }

    private void generateList()
    {
        statList.Add(strength);
        statList.Add(dexterity);

        statList.Add(endurance);

        statList.Add(intelligence);
        statList.Add(perception);

        statList.Add(charisma);
        statList.Add(coldBlood);
        statList.Add(luck);
    }

    public List<PlayerStat> getStatList()
    {
        return statList;
    }

    public void gainExperience(int amount)
    {
        experience += amount;
        if(experience >= requiredExperience)
        {
            levelUp();
            increaseXpCap();
        }
    }

    private void increaseXpCap()
    {

    }

    private void levelUp()
    {

    }
}
