using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplyPowerUp_Player : MonoBehaviour
{
    public PowerUp powerUpEffect;
    public GameObject player;

    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => powerUpEffect.Apply(player));
    }
}
