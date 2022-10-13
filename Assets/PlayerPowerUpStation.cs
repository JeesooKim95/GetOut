using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpStation : MonoBehaviour
{
    public GameObject menu;
    public Material OnActive;
    public Material OnDeactive;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = OnActive;
            menu.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = OnDeactive;
            menu.SetActive(false);
        }
    }
}
