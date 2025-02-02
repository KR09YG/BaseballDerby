using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homerun : MonoBehaviour
{
    [SerializeField] Text _homerunTex;

    [SerializeField] Text _result;

    static int _homerunCount = 0;

    Pitcher _pitch;

    private void Awake()
    {
        _pitch = FindAnyObjectByType<Pitcher>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _homerunCount++;
            _result.text = _homerunCount.ToString();
            Debug.Log("Homerun");
            _pitch.Pitch.Invoke();
            Destroy(collision.gameObject);
            //_homerunTex.text = "Homerun";
        }
    }
}
