using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiflePowerUpMenu : MonoBehaviour
{
    public Button DamageUpButton;
    public Button MagUpButton;
    public TextMeshProUGUI CurrentStat;
    public GameObject gun;
    private Gun weapon;

    void Start()
    {
        DamageUpButton.gameObject.SetActive(false);
        MagUpButton.gameObject.SetActive(false);
        weapon = gun.GetComponent<Gun>();
        var dropDown = transform.GetComponent<TMP_Dropdown>();
        dropDown.options.Clear();

        List<string> Selection = new List<string>();

        Selection.Add("Damage");
        Selection.Add("Magazine Size");

        foreach(var select in Selection)
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
            MagUpButton.gameObject.SetActive(false);
        }
        //Mag Size
        else if(index == 1)
        {
            CurrentStat.text = "Current Magazine Size : " + weapon.GetMagSize();
            MagUpButton.gameObject.SetActive(true);
            DamageUpButton.gameObject.SetActive(false);
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
            CurrentStat.text = "Current Magazine Size : " + weapon.GetMagSize();
        }
    }
}
