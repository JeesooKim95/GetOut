using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Quitgame);
    }

    void Quitgame()
    {
        Application.Quit();
    }
}
