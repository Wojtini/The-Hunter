using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCellUI : MonoBehaviour
{
    PlayerStat stat;
    public Text statName;
    public Text statValue;
    public void setStat(PlayerStat stat)
    {
        this.stat = stat;
    }
    public void updateStatValue()
    {
        this.statName.text = this.stat.name;
        this.statValue.text = this.stat.value.ToString();
    }
    public void onButtonClick(int amount)
    {
        stat.value += amount;
        PlayerStatsUI.instance.UpdateStatView();
    }
}
