using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject statPanel;
    public static PlayerStatsUI instance;
    // Update is called once per frame
    private void Start()
    {
        panel.gameObject.SetActive(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
            UpdateStatView();
        }
    }

    public void UpdateStatView()
    {
        DestroyAllChildren();
        foreach (PlayerStat stat in PlayerStats.instance.getStatList())
        {
            StatCellUI entry = Instantiate(statPanel, panel.transform).GetComponent<StatCellUI>();
            entry.setStat(stat);
            entry.updateStatValue();
        }
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
