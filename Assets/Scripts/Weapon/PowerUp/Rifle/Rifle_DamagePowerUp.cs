using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Rifle_DamagePowerUp")]

public class Rifle_DamagePowerUp : PowerUp
{
    public int amount, cost;
    GameObject player;
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
            target.GetComponent<Gun>().IncreaseDamage(amount);
            PM.DecreasePoint(cost);
        }        
    }
}