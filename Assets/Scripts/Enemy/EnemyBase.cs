using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int maxHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maxHealth <= 0)
        {
            Destroy(gameObject);
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
    }
}
