using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homerun : MonoBehaviour
{
    [SerializeField] GameObject _homerunTex;

    [SerializeField] Text _result;

    [SerializeField] AudioSource _cheeringSe;

    Pitcher _pitch;

    PointManager _pointManager;

    private void Awake()
    {
        _pointManager = FindAnyObjectByType<PointManager>();
        _pitch = FindAnyObjectByType<Pitcher>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _pointManager.PointUp(1);
            _cheeringSe.Play();
            Debug.Log("Homerun");
            _pitch.Pitch.Invoke();
            _homerunTex.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
