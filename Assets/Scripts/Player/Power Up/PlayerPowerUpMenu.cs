using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class PlayerPowerUpMenu : MonoBehaviour
{
    public Button HealthUpButton;
    public Button SpeedUpButton;
    public TextMeshProUGUI CurrentStat;
    public GameObject player;
    public XROrigin origin;
    private PlayerMovement playerHandle;
    private Health playerHealth;

    void Start()
    {
        HealthUpButton.gameObject.SetActive(false);
        SpeedUpButton.gameObject.SetActive(false);
        playerHealth = player.GetComponent<Health>();
        playerHandle = origin.GetComponent<PlayerMovement>();
        var dropDown = transform.GetComponent<TMP_Dropdown>();
        dropDown.options.Clear();

        List<string> Selection = new List<string>();

        Selection.Add("Health");
        Selection.Add("Speed");

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
            CurrentStat.text = "Current Health : " + playerHealth.GetMaxHealth();
            HealthUpButton.gameObject.SetActive(true);
            SpeedUpButton.gameObject.SetActive(false);
        }
        //Mag Size
        else if (index == 1)
        {
            CurrentStat.text = "Current Speed : " + playerHandle.GetSpeed();
            SpeedUpButton.gameObject.SetActive(true);
            HealthUpButton.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        var dropDown = transform.GetComponent<TMP_Dropdown>();

        int index = dropDown.value;
        //Damage
        if (index == 0)
        {
            CurrentStat.text = "Current Health : " + playerHealth.GetMaxHealth();
        }
        //Mag Size
        else if (index == 1)
        {
            CurrentStat.text = "Current Speed : " + playerHandle.GetSpeed();
        }
    }
}
