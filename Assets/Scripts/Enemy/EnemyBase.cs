using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBase : MonoBehaviour
{
    private int currentLevel = 1;
    public int currHealth = 100;
    public int damage = 10;
    public int point = 1;
    public float speed = 1.0f;
    public NavMeshAgent agent;
    public Rigidbody rb;
    protected State currentState = null;
    protected EnemyAnim_Base anim = null;
    private float deathAnimTimer = 1.5f;
    PointManager PM;

    public float speedIncrement = 0.2f;
    public int damageIncrement = 5;
    public int healthIncrement = 40;
    private bool levelup = false;

    protected virtual void Start()
    {
        PM = GameObject.Find("PM").GetComponent<PointManager>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        anim = gameObject.GetComponent<EnemyAnim_Base>();         
    }

    protected virtual void FixedUpdate()
    {
        //if(levelup)
        //{
        //    Debug.Log("level up enemy : " + currentLevel);
        //    speed += currentLevel * speedIncrement;
        //    damage += currentLevel * damageIncrement;
        //    GetComponent<Health>().maxHealth += currentLevel * healthIncrement;
        //    levelup = false;
        //}

        currHealth = GetComponent<Health>().currHealth;
        if(currHealth < 0)
        {
            anim.Death(true);
            FindObjectOfType<AudioManager>().Play("Zombie_Death");
            deathAnimTimer -= Time.deltaTime;
            if(deathAnimTimer < 0)
            {
                PM.IncreasePoint(point);
                Destroy(gameObject);
            }
        }
        else
        {
            currentState.FixedUpdate();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Bullet")
    //    {
    //        currHealth -= collision.gameObject.GetComponent<Bullet>().GetDamage();
    //    }
    //    else if(collision.gameObject.tag == "Weapon_Melee")
    //    {
    //        currHealth -= collision.gameObject.GetComponent<Melee>().GetDamage();
    //    }
    //}

    protected void SetState(State state)
    {
        currentState = state;
        currentState.Initialize(gameObject, anim);
        Debug.Log("Enemy Set State : " + state.name);
    }

    public void PowerUpEnemy(int lv)
    {
        Debug.Log("Current level is : " + lv);

        currentLevel = lv;
        levelup = true;
    }
}
