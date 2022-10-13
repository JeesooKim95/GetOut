using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    //Basic Features
    public int _damage = 50;
    public int _shield = 500;

    //For projectile shooting
    public GameObject projectile;
    public Transform aimPoint;
    public int projectileStack = 2;
    public float projectileCoolTime = 3.0f;

    //Dash 
    public float dashCoolTime = 5.0f;
    public float maxChargeTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDamage(int amount)
    {
        _damage += amount;
    }
    
    public void IncreaseShield(int amount)
    {
        _shield += amount;
    }

    public int GetDamage()
    {
        return _damage;
    }
    
    public int GetShield()
    {
        return _shield;
    }
}
