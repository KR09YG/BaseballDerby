using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pitcher : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _releasePoint;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _ballImageObj;
    [SerializeField] Image[] _remainingImg;
    [SerializeField] GameObject _resultPanel;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] int _remaingCount;
    bool _isPause = false;
    public Action Pitch;

    private void Awake()
    {
        _resultPanel.SetActive(false);
        Pitch = Pitching;
        Pitch.Invoke();
    }

    private void Pitching()
    {
        if (!_isPause)
        {
            if (_remaingCount == 0)
            {
                _resultPanel.SetActive(true);
            }
            else
            {
                this.transform.position = new Vector3(0, 0.77f, 32.87f);
                StartCoroutine(Release(2.02f, 3f));
                Debug.Log("Pitching");
            }
        }
        else
        {
            _pausePanel.SetActive(true);
        }
    }

    public void Pause()
    {
        _isPause = true;
    }

    public void RePause()
    {
        _isPause = false;
        Pitching();
    }

    IEnumerator Release(float time, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.Play("Pitching");
        yield return new WaitForSeconds(time);
        _remaingCount--;
        _remainingImg[_remaingCount].enabled = false;
        _ballImageObj.SetActive(false);
        Instantiate(_ball, _releasePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        _ballImageObj.SetActive(true);
    }
}
