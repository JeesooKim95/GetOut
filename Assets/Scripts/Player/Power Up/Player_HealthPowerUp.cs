using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Player_HealthPowerUp")]

public class Player_HealthPowerUp : PowerUp
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().IncreaseMaxHealth(amount);
        Debug.Log("Health Increased!");
        Debug.Log("Current Health : " + target.GetComponent<Health>().GetMaxHealth());
    }
}
