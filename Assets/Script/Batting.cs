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
    float _power = 10;
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
            _center.z += 4;
        }

        if (_isSupport)
        {
            var supportCenter = _center;
            supportCenter.z = _center.z + 1;
            var s = Physics.OverlapBox(supportCenter, _size, Quaternion.identity, _baseballLayer);
            _supportButtonImage.color = Color.red;
            foreach (var c in s)
            {
                c.GetComponent<MeshRenderer>().material = _supportMaterial;
            }
        }
        else
        {
            _supportButtonImage.color = Color.white;
        }

        var cols = Physics.OverlapBox(_center, _size, Quaternion.identity, _baseballLayer);

        if (Input.GetMouseButtonDown(0) && !_isSwing)
        {
            _isSwing = true;
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
                    _power += 1.5f;
                }

                reflection.y = c.transform.position.y > _center.y ? 3f : -1f;


                _rbBall.velocity = Vector3.zero;

                Debug.Log(reflection);

                _rbBall.AddForce(reflection * _power, ForceMode.Impulse);

                _power = 10;
            }
        }

        if (_rbBall != null)
        {
            _rbBall.AddForce(new Vector3(0, -1.5f, 0));
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
