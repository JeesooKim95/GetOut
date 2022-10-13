using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Melee_ShieldPowerUp")]
public class Melee_ShieldPowerUp : PowerUp
{
    public int amount;

    public override void Apply(GameObject target)
    {
        //target.GetComponent<Melee>().IncreaseDamage(amount);
        GameObject[] meleeSet = GameObject.FindGameObjectsWithTag("Weapon_Melee");
        foreach (var melee in meleeSet)
        {
            melee.GetComponent<Melee>().IncreaseShield(amount);
        }
        Debug.Log("Shield Increased!");
        Debug.Log("Current Shield : " + target.GetComponent<Melee>().GetShield());
    }
}