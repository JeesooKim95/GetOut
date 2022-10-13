using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currHealth;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }
}
