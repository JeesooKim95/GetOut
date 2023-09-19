using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int point = 0;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public int GetPoint()
    {
        return point;
    }

    public void IncreasePoint(int _p)
    {
        point += _p;
    }

    public void DecreasePoint(int _p)
    {
        point -= _p;
    }

    public void Reset()
    {
        point = 0;
    }

}
