using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _releasePoint;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _ballImageObj;
    public Action Pitch;

    private void Awake()
    {
        Pitch = Pitching;
        Pitch.Invoke();
    }

    private void Pitching()
    {
        this.transform.position = new Vector3(0, 0.77f, 32.87f);
        StartCoroutine(Release(2.02f,3f));
        Debug.Log("Pitching");
    }

    IEnumerator Release(float time,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.Play("Pitching");
        yield return new WaitForSeconds(time);
        _ballImageObj.SetActive(false);
        Instantiate(_ball, _releasePoint.position,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        _ballImageObj.SetActive(true);
    }
}
