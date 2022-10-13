using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

[CreateAssetMenu(menuName = "PowerUp/Player_SpeedPowerUp")]

public class Player_SpeedPowerUp : PowerUp
{
    public int amount;
    private XROrigin origin;

    public override void Apply(GameObject target)
    {
        origin = target.GetComponentInChildren<XROrigin>();
        origin.GetComponent<PlayerMovement>().IncreaseSpeed(amount);
        Debug.Log("Speed Increased!");
        Debug.Log("Current Speed : " + origin.GetComponent<PlayerMovement>().GetSpeed());
    }
}
