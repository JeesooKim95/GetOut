using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStation : MonoBehaviour
{
    public GameObject RifleMenu;
    public GameObject MeleeMenu;
    public GameObject PlayerMenu;
    public GameObject WaveMenu;
    public GameObject PointMenu;
    public Material OnActive;
    public Material OnDeactive;
    // Start is called before the first frame update
    void Start()
    {
        WaveMenu.SetActive(true);
        PlayerMenu.SetActive(true);
        PointMenu.SetActive(true);
        RifleMenu.SetActive(false);
        MeleeMenu.SetActive(false);
    }

    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            WaveMenu.SetActive(true);
            PlayerMenu.SetActive(true);
        }
        else
        {
            WaveMenu.SetActive(false);
            PlayerMenu.SetActive(false);
            RifleMenu.SetActive(false);
            MeleeMenu.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision : " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Weapon_Gun")
        {
            gameObject.GetComponent<Renderer>().material = OnActive;
            PlayerMenu.SetActive(false);
            RifleMenu.SetActive(true);
        }
        if (collision.gameObject.tag == "Weapon_Melee")
        {
            gameObject.GetComponent<Renderer>().material = OnActive;
            PlayerMenu.SetActive(false);
            MeleeMenu.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon_Gun")
        {
            gameObject.GetComponent<Renderer>().material = OnDeactive;
            RifleMenu.SetActive(false);
            PlayerMenu.SetActive(true);
        }
        if (collision.gameObject.tag == "Weapon_Melee")
        {
            gameObject.GetComponent<Renderer>().material = OnDeactive;
            MeleeMenu.SetActive(false);
            PlayerMenu.SetActive(true);
        }
    }


}
