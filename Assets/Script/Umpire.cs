using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umpire : MonoBehaviour
{
    Pitcher _pitch;

    private void Awake()
    {
        _pitch = FindAnyObjectByType<Pitcher>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            _pitch.Pitch.Invoke();
        }
    }
}
