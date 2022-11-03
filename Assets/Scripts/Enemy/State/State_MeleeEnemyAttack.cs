using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MeleeEnemyAttack : State
{
    float attackRange = 2.0f;
    private Transform attackPoint;
    private LayerMask playerLayer;
    private int damage = 10;
    GameObject player;
    private float attackCooldown = 2.0f;

    public override void Initialize(GameObject _enemy, EnemyAnim_Base anim)
    {
        base.Initialize(_enemy, anim);
        name = "Attack";
        if (enemy.agent != null)
        {
            enemy.agent.speed = 0.0f;
        }
        anim.Walk(false);
        anim.Attack();
        attackPoint = enemy.transform;
        player = GameObject.Find("Player");
        playerLayer = player.layer;
    }

    public override void FixedUpdate()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        else
        {
            if (Physics.CheckSphere(attackPoint.position, attackRange, playerLayer) == true)
            {
                attackCooldown = 2.0f;
                player.GetComponent<Health>().TakeDamage(damage);
                //Debug.Log("Player HIT");
            }
        }        
    }

    public override void Exit()
    {

    }
}
