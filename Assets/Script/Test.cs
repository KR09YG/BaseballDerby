using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Transform _gameObject;
    [SerializeField] Transform _gameObject2;
    void Start()
    {
        Vector2 a = new Vector2(_gameObject.position.x - this.transform.position.x, _gameObject.position.z - this.transform.position.z);
        Vector2 b = new Vector2(_gameObject2.position.x - this.transform.position.x, _gameObject2.position.z - this.transform.position.z);
        Debug.Log(Vector2.Angle(a, b));
    }

}
