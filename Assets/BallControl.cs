using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Transform _target;
    public ContactPoint contact;
    [SerializeField] float[] _ballSpeed;
    [SerializeField] Vector3 _gravity;
    Orbit _orbit;
    Rigidbody _rb;
    int n;

    public enum Balltype
    {
        Straight,
        ChangeUp,
        Slider,
        Chute,
        Fork,
        Curve,
        Split
    }


    void Start()
    {
        _target = GameObject.FindWithTag("Target").GetComponent<Transform>();
        _orbit = GetComponent<Orbit>();
        _rb = GetComponent<Rigidbody>();
        n = Random.Range(0, 7);
        //_rb.AddForce(transform.up * -_gravity, ForceMode.Impulse);
        Vector3 targetDis = (_target.position - this.transform.position).normalized;
        switch (n)
        {
            case 0:
                _rb.AddForce(targetDis * _ballSpeed[0], ForceMode.Impulse);
                break;
            case 1:
                _rb.AddForce(targetDis * _ballSpeed[1], ForceMode.Impulse);
                break;
            case 2:
                _rb.AddForce(targetDis * _ballSpeed[2], ForceMode.Impulse);
                break;
            case 3:
                _rb.AddForce(targetDis * _ballSpeed[3], ForceMode.Impulse);
                break;
            case 4:
                _rb.AddForce(targetDis * _ballSpeed[4], ForceMode.Impulse);
                break;
            case 5:
                _rb.AddForce(targetDis * _ballSpeed[5], ForceMode.Impulse);
                break;
            case 6:
                _rb.AddForce(targetDis * _ballSpeed[6], ForceMode.Impulse);
                break;
            case 7:
                _rb.AddForce(targetDis * _ballSpeed[7], ForceMode.Impulse);
                break;
        }       
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector3(0, 9.8f, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            _rb.velocity = Vector3.zero;
            //_orbit.enabled = true;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Change"))
        {
            if (n == 2)
            {
                StartCoroutine(Change(3f, new Vector3(-1f, 0, 0)));
            }//スライダー
            else if (n == 3)
            {
                StartCoroutine(Change(1.5f, new Vector3(-1f, 0, 0)));
            }//カットボール
            else if (n == 4)
            {
                StartCoroutine(Change(0.5f, new Vector3(0, -1f, 0)));
            }//フォークボール
            else if (n == 5)
            {
                StartCoroutine(Change(1.5f, new Vector3(1f, 0, 0)));
            }//シュートボール
            else if (n == 6)
            {
                StartCoroutine(Change(1.5f, new Vector3(-1f, -0.5f, 0)));
            }//カーブボール
            else if (n == 7)
            {
                StartCoroutine(Change(1.5f, new Vector3(1.5f, -0.7f, 0)));
            }//スプリット
        }
    }

    

    /// <summary>
    /// 変化球の処理
    /// </summary>
    /// <param 変化量　=　"n"></param>
    /// <param 変化する方向　=　"changingDirection"></param>
    IEnumerator Change(float n, Vector3 changingDirection)
    {
        while (true)
        {
            _rb.AddForce(changingDirection * n);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
