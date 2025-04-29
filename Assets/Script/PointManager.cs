using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] Text _result;
    int _homerunPoint;
    public void PointUp(int p)
    {
        _homerunPoint += p;
        _result.text = _homerunPoint.ToString();
    }
}
