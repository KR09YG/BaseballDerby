using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homerun : MonoBehaviour
{
    [SerializeField] Text _homerunTex;

    Pitcher _pitch;

    private void Awake()
    {
        _pitch = FindAnyObjectByType<Pitcher>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Homerun");
            _pitch.Pitch.Invoke();
            Destroy(collision.gameObject);
            //_homerunTex.text = "Homerun";
        }
    }
}
