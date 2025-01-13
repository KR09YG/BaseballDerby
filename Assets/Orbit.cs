using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Vector3 _velocity;
    [SerializeField] Vector3 _gravity;
    Rigidbody _rb;
    bool _isBatting = false;

    private void Update()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            _velocity = _rb.velocity;
            _velocity.z *= -1;
            Debug.Log(_velocity.normalized);
            _rb.AddForce(_velocity.normalized * 10f, ForceMode.Impulse);
            _isBatting = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isBatting)
        {
            _rb.AddForce(_gravity, ForceMode.Impulse);
        }
    }
}
