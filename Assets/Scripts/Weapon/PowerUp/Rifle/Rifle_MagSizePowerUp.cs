using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Rifle_MagSizePowerUp")]

public class Rifle_MagSizePowerUp : PowerUp
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
            target.GetComponent<Gun>().IncreaseMagSize(amount);
            PM.DecreasePoint(cost);
        }            
    }
}
