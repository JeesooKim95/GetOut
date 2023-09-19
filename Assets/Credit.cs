using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Credit : MonoBehaviour
{
    public GameObject credit;
    private Button button;
    private bool toggle = false;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadCredit);
    }

    void LoadCredit()
    {
        credit.SetActive(true);
    }
}
