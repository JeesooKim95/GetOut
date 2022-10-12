using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Rifle_DamagePowerUp")]

public class Rifle_DamagePowerUp : PowerUp
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Gun>().IncreaseDamage(amount);
        Debug.Log("Damage Increased!");
        Debug.Log("Current Damage : " + target.GetComponent<Gun>().damage);
    }
}