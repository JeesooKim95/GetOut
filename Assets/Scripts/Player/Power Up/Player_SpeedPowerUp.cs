using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

[CreateAssetMenu(menuName = "PowerUp/Player_SpeedPowerUp")]

public class Player_SpeedPowerUp : PowerUp
{
    public int cost;
    public float amount;
    private XROrigin origin;
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
                origin = target.GetComponentInChildren<XROrigin>();
                origin.GetComponent<PlayerMovement>().IncreaseSpeed(amount);
                PM.DecreasePoint(cost);
            }              
    }
}
