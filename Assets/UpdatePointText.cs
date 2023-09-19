using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdatePointText : MonoBehaviour
{
    public TextMeshProUGUI CurrentPoint;
    private PointManager PM;
    // Start is called before the first frame update
    void Awake()
    {
        PM = GameObject.Find("PM").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PM != null)
        {
            CurrentPoint.SetText("Point : " + PM.GetPoint());
        }
    }
}
