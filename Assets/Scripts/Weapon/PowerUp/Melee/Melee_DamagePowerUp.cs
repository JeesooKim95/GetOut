using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Melee_DamagePowerUp")]
public class Melee_DamagePowerUp : PowerUp
{
    public int amount;

    public override void Apply(GameObject target)
    {
        //target.GetComponent<Melee>().IncreaseDamage(amount);
        GameObject[] meleeSet = GameObject.FindGameObjectsWithTag("Weapon_Melee");
        foreach(var melee in meleeSet)
        {
            melee.GetComponent<Melee>().IncreaseDamage(amount);
        }
        Debug.Log("Damage Increased!");
        Debug.Log("Current Damage : " + target.GetComponent<Melee>().GetDamage());
    }
}
