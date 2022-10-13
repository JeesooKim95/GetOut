using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeleePowerUpMenu : MonoBehaviour
{
    public Button DamageUpButton;
    public Button ShiledUpButton;
    public TextMeshProUGUI CurrentStat;
    public GameObject gauntlet;
    private Melee weapon;

    void Start()
    {
        DamageUpButton.gameObject.SetActive(false);
        ShiledUpButton.gameObject.SetActive(false);
        weapon = gauntlet.GetComponent<Melee>();
        var dropDown = transform.GetComponent<TMP_Dropdown>();
        dropDown.options.Clear();

        List<string> Selection = new List<string>();

        Selection.Add("Damage");
        Selection.Add("Shield");

        foreach (var select in Selection)
        {
            dropDown.options.Add(new TMP_Dropdown.OptionData() { text = select });
        }

        DropDownSelected(dropDown);

        dropDown.onValueChanged.AddListener(delegate { DropDownSelected(dropDown); });
    }


    void DropDownSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        //Damage
        if (index == 0)
        {
            CurrentStat.text = "Current Damage : " + weapon.GetDamage();
            DamageUpButton.gameObject.SetActive(true);
        }
        //Shield
        else if(index == 1)
        {
            CurrentStat.text = "Current Shield : " + weapon.GetShield();
            ShiledUpButton.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        var dropDown = transform.GetComponent<TMP_Dropdown>();

        int index = dropDown.value;
        //Damage
        if (index == 0)
        {
            CurrentStat.text = "Current Damage : " + weapon.GetDamage();
        }
        //Mag Size
        else if(index == 1)
        {
            CurrentStat.text = "Current Shield : " + weapon.GetShield();
        }
    }
}
