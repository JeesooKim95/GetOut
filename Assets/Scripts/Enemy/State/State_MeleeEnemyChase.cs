using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class State_MeleeEnemyChase : State
{
    public GameObject player;

    public override void Initialize(GameObject _enemy, EnemyAnim_Base anim)
    {
        base.Initialize(_enemy, anim);
        name = "Chase";
        player = GameObject.Find("Player");
        anim.Walk(true);
        if (enemy.agent != null)
        {
            enemy.agent.enabled = true;
            enemy.agent.speed = 1.0f;
        }
    }

    public override void FixedUpdate()
    {
        if (enemy.agent != null)
            enemy.agent.SetDestination(player.transform.position);
    }

    public override void Exit()
    {

    }
}
