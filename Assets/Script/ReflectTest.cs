using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ReflectTest : MonoBehaviour
{
    bool _isBatting = false;
    [SerializeField] Vector3 _gravity;
    Transform _front;
    Transform _umpire;
    Rigidbody _rb;
    [SerializeField] float _power;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _front = GameObject.FindWithTag("Front").GetComponent<Transform>();
        _umpire = GameObject.FindWithTag("Umpire").GetComponent<Transform>();
        Debug.Log(_front);
        Debug.Log(_umpire);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Bat"))
        {
            float xyAngle = AngleXZ() - 90;
            Debug.Log(xyAngle);
            float yAngle = Angle(collision);
            Debug.Log(yAngle);
            float vx = _power * Mathf.Cos(yAngle * Mathf.Deg2Rad) * Mathf.Cos(xyAngle * Mathf.Deg2Rad);
            float vy = _power * Mathf.Sin(yAngle * Mathf.Deg2Rad);
            float vz = _power * Mathf.Cos(yAngle * Mathf.Deg2Rad) * Mathf.Sin(xyAngle * Mathf.Deg2Rad);
            _rb.velocity = Vector3.zero;
            Debug.Log(vx + " "  + " " + vy + " " + vz);
            _rb.AddForce(vx, vy, vz,ForceMode.Impulse);
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

    private float AngleXZ()
    {
        Transform myPos = transform;
        Vector2 obj1 = new Vector2(_umpire.position.x - _front.position.x, _umpire.position.z - _front.position.z);    
        Vector2 obj2 = new Vector2(_umpire.position.x - myPos.position.x, _umpire.position.z - myPos.position.z);
        
        return Vector2.Angle(obj1,obj2);
    }

    private float Angle(Collision collision)
    {
        Vector3 obj = collision.transform.position - this.transform.position;
        return Vector3.Angle(obj,collision.gameObject.transform.forward);
    }
    
}
