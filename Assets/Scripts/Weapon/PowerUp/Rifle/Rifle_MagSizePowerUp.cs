using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Rifle_MagSizePowerUp")]

public class Rifle_MagSizePowerUp : PowerUp
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Gun>().IncreaseMagSize(amount);
        Debug.Log("Mag Size Increased!");
        Debug.Log("Current Mag Size : " + target.GetComponent<Gun>().magSize);
    }
}
