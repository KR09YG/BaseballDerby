using System.Collections;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Transform _target;
    public ContactPoint contact;
    [SerializeField] float[] _ballSpeed;
    Orbit _orbit;
    Rigidbody _rb;
    Vector3 _distance;
    int n;

    void Start()
    {
        _target = GameObject.FindWithTag("Target").GetComponent<Transform>();
        _distance = this.transform.position - _target.position;
        _orbit = GetComponent<Orbit>();
        _rb = GetComponent<Rigidbody>();
        n = Random.Range(0, 8);
        Vector3 targetDis = (_target.position - this.transform.position).normalized;
        switch (n)
        {
            case 0:
                _rb.AddForce(targetDis * _ballSpeed[0], ForceMode.Impulse);
                Debug.Log("ストレート");
                break;
            case 1:
                _rb.AddForce(targetDis * _ballSpeed[1], ForceMode.Impulse);
                Debug.Log("チェンジアップ");
                break;
            case 2:
                _rb.AddForce(targetDis * _ballSpeed[2], ForceMode.Impulse);
                StartCoroutine(Change(3f, new Vector3(-1f, 0, 0)));
                Debug.Log("スライダー");
                break;
            case 3:
                _rb.AddForce(targetDis * _ballSpeed[3], ForceMode.Impulse);
                StartCoroutine(Change(1f, new Vector3(-1f, 0, 0)));
                Debug.Log("カット");
                break;
            case 4:
                _rb.AddForce(targetDis * _ballSpeed[4], ForceMode.Impulse);
                StartCoroutine(Change(1.5f, new Vector3(0, -1f, 0)));
                Debug.Log("フォーク");
                break;
            case 5:
                _rb.AddForce(targetDis * _ballSpeed[5], ForceMode.Impulse);
                StartCoroutine(Change(1f, new Vector3(1f, 0, 0)));
                Debug.Log("シュート");
                break;
            case 6:
                _rb.AddForce(targetDis * _ballSpeed[6], ForceMode.Impulse);
                StartCoroutine(Change(1.5f, new Vector3(-1f, -1f, 0)));
                Debug.Log("カーブ");
                break;
            case 7:
                _rb.AddForce(targetDis * _ballSpeed[7], ForceMode.Impulse);
                StartCoroutine(Change(1.5f, new Vector3(1.5f, -0.7f, 0)));
                Debug.Log("スプリット");
                break;
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            _rb.velocity = Vector3.zero;
            this.enabled = false;
        }
    }
    
    /// <summary>
    /// 変化球の処理
    /// </summary>
    /// <param 変化量　=　"n"></param>
    /// <param 変化する方向　=　"changingDirection"></param>
    IEnumerator Change(float n, Vector3 changingDirection)
    {
        _distance /= 2;
        Debug.Log(_distance);
        while (true)
        {
            _rb.AddForce(changingDirection * n);
            yield return new WaitForSeconds(0.1f);
        }
       
    }
}
