using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    Pitcher _pitch;

    private void Awake()
    {
        _pitch = FindAnyObjectByType<Pitcher>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            _pitch.Pitch.Invoke();
        }
    }
}
