using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batting : MonoBehaviour
{
    [SerializeField] Image _cursor = default;
    [SerializeField] Vector3 _size = Vector3.one;
    [SerializeField] LayerMask _meetareaLayer = default;
    [SerializeField] LayerMask _baseballLayer = default;
    float _power = 10;
    Rigidbody _rbBall;
    Vector3 _center = default;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, _meetareaLayer))
        {
            _cursor.rectTransform.position = Input.mousePosition;
            _center = hitInfo.point;

        }

        if (Input.GetMouseButtonDown(0))
        {
            var cols = Physics.OverlapBox(_center, _size, Quaternion.identity, _baseballLayer);

            foreach (var c in cols)
            {
                _rbBall = c.GetComponent<Rigidbody>();

                Vector3 reflection = Vector3.zero;

                reflection.z = 5f;

                reflection.x = Random.Range(-5,5);

                if (reflection.x == 0)
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
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_center, _size);
    }
}
