using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Player_HealthPowerUp")]

public class Player_HealthPowerUp : PowerUp
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
            target.GetComponent<Health>().IncreaseMaxHealth(amount);
            PM.DecreasePoint(cost);
        }
    }
}
