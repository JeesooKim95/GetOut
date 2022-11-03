using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBase : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 10;
    public NavMeshAgent agent;
    public Rigidbody rb;
    protected State currentState = null;
    protected EnemyAnim_Base anim = null;
    private float deathAnimTimer = 1.5f;
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        anim = gameObject.GetComponent<EnemyAnim_Base>();
    }

    protected virtual void FixedUpdate()
    {
        if(maxHealth < 0)
        {
            anim.Death(true);
            deathAnimTimer -= Time.deltaTime;
            if(deathAnimTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            currentState.FixedUpdate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            maxHealth -= collision.gameObject.GetComponent<Bullet>().GetDamage();
        }
        else if(collision.gameObject.tag == "Weapon_Melee")
        {
            maxHealth -= collision.gameObject.GetComponent<Melee>().GetDamage();
        }

        //if(collision.gameObject.tag == "Player" && currentState.name == "Attack")
        //{
        //    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        //}
    }

    protected void SetState(State state)
    {
        currentState = state;
        currentState.Initialize(gameObject, anim);
        Debug.Log("Enemy Set State : " + state.name);
    }
}
