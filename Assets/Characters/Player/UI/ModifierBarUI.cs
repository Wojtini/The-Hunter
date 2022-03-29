using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierBarUI : MonoBehaviour
{
    public static ModifierBarUI instance;
    public GameObject modifierIconTemplate;
    public CharacterModifiers characterModifiers;
    // Update is called once per frame
    private void Start()
    {
        instance = this;
        characterModifiers = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterModifiers>();
    }

    private void Update()
    {
        UpdateBar();
    }
    void UpdateBar()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Modifier m in characterModifiers.modifiers)
        {
            GameObject go = Instantiate(modifierIconTemplate, transform);
            go.GetComponent<Image>().sprite = m.icon;
        }
    }
}
