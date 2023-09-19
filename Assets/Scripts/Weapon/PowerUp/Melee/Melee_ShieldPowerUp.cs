using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Melee_ShieldPowerUp")]
public class Melee_ShieldPowerUp : PowerUp
{
    public int amount, cost;
    PointManager PM;

    public override void Awake()
    {
        
    }

    public override void Apply(GameObject target)
    {
        GameObject _pm = GameObject.FindGameObjectWithTag("PointManager");
        PM = _pm.GetComponent<PointManager>();
        if (PM.point >= cost)
        {
            GameObject[] meleeSet = GameObject.FindGameObjectsWithTag("Weapon_Melee");
            foreach (var melee in meleeSet)
            {
                melee.GetComponent<Melee>().IncreaseShield(amount);
            }
            PM.DecreasePoint(cost);
        }        
    }
}