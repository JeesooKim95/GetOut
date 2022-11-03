using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Melee : EnemyBase
{
    State_MeleeEnemyChase chaseState = new State_MeleeEnemyChase();
    State_MeleeEnemyAttack attackState = new State_MeleeEnemyAttack();
    float attackRange = 2.0f;
    GameObject player;

    protected override void Start()
    {
        base.Start();
        SetState(chaseState);
        player = GameObject.Find("Player");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (currentState == chaseState)
        {
            if (distance <= attackRange)
            {
                SetState(attackState);
            }
        }
        else if (currentState == attackState)
        {
            if (distance <= attackRange)
            {
                attackState.Initialize(gameObject, anim);
            }
            else
            {
                SetState(chaseState);
            }
        }
    }

}
