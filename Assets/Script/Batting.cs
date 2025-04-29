using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batting : MonoBehaviour
{
    [SerializeField] Image _cursor;
    [SerializeField] Vector3 _size;
    [SerializeField] LayerMask _meetareaLayer;
    [SerializeField] LayerMask _baseballLayer;
    [SerializeField] Material _supportMaterial;
    [SerializeField] Material _defaultMaterial;
    [SerializeField] Image _supportButtonImage;
    [SerializeField] AudioSource[] _battingSe;
    float _power = 11;
    bool _isSwing = false;
    bool _isSupport = false;
    Rigidbody _rbBall;
    Vector3 _center;
    public Vector3 Cursor { get; private set; }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, _meetareaLayer))
        {
            _cursor.rectTransform.position = Input.mousePosition;
            _center = hitInfo.point;
            Cursor = _center;
        }

        //if (_isSupport)
        //{
        //    var supportCenter = _center;
        //    supportCenter.z = _center.z + 4;
        //    var s = Physics.OverlapBox(supportCenter, _size * 1.1f, Quaternion.identity, _baseballLayer);
        //    _supportButtonImage.color = Color.red;
        //    foreach (var c in s)
        //    {
        //        c.GetComponent<MeshRenderer>().material = _supportMaterial;
        //    }
        //}
        //else
        //{
        //    _supportButtonImage.color = Color.white;
        //}


    }

    public void StartSwing()
    {
        _isSwing = true;
    }

    public void FinishSwing()
    {
        _isSwing = false;
    }

    private void FixedUpdate()
    {
        if (_rbBall)
        {
            _rbBall.AddForce(new Vector3(0, -9.8f * 1.2f, 0));
        }

        if (_isSwing)
        {
            var cols = Physics.OverlapBox(_center, _size, Quaternion.identity, _baseballLayer);

            StartCoroutine(SwingInterval());

            foreach (var c in cols)
            {
                _rbBall = c.GetComponent<Rigidbody>();

                c.GetComponent<TrailRenderer>().enabled = true;

                Vector3 reflection = Vector3.zero;

                reflection.z = 5f;

                reflection.x = Random.Range(-5, 5);

                if (-1 <= reflection.x && reflection.x <= 1)
                {
                    _power += 2f;
                }

                reflection.y = c.transform.position.y > _center.y ? 2f : -1f;

                _rbBall.velocity = Vector3.zero;

                Debug.Log(reflection);

                _rbBall.AddForce(reflection * _power, ForceMode.Impulse);

                _battingSe[Random.Range(0, 3)].Play();

                _power = 11;

                _isSwing = false;
            }
        }
    }

    public void Support()
    {
        _isSupport = !_isSupport;
    }

    IEnumerator SwingInterval()
    {
        yield return new WaitForSeconds(1);
        _isSwing = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_center, _size);
    }
}
