using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Melee_DamagePowerUp")]
public class Melee_DamagePowerUp : PowerUp
{
    public int amount, cost;
    private GameObject player;
    PointManager PM;

    public override void Awake()
    {
        player = GameObject.Find("Player");        
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
                melee.GetComponent<Melee>().IncreaseDamage(amount);
            }
            PM.DecreasePoint(cost);
        }
        
    }
}
