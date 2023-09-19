using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currHealth;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player" && currHealth < 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
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
