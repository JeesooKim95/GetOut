using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStation : MonoBehaviour
{
    public GameObject RifleMenu;
    public GameObject MeleeMenu;
    // Start is called before the first frame update
    void Start()
    {
        RifleMenu.SetActive(false);
        MeleeMenu.SetActive(false);
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision : " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Weapon_Gun")
        {
            RifleMenu.SetActive(true);
        }
        if (collision.gameObject.tag == "Weapon_Melee")
        {
            MeleeMenu.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon_Gun")
        {
            RifleMenu.SetActive(false);
        }
        if (collision.gameObject.tag == "Weapon_Melee")
        {
            MeleeMenu.SetActive(false);
        }
    }


}
