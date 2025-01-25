using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foul : MonoBehaviour
{
    Pitcher _pitch;
    private void Awake()
    {
        _pitch = FindAnyObjectByType<Pitcher>();
    }
    private void Update()
    {
        if (this.transform.position.y < -20)
        {
            Destroy(this.gameObject);
            _pitch.Pitch.Invoke();
        }
    }
}
