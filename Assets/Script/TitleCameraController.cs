using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleCameraController : MonoBehaviour
{
    SceneChange _sceneChanger;
    [SerializeField] Image _image;
    Animator _animator;
    public void GameStart()
    {
        _sceneChanger = FindAnyObjectByType<SceneChange>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("GameStart");
        StartCoroutine(ChangeSceneInterval());
    }

    IEnumerator ChangeSceneInterval()
    {
        yield return new WaitForSeconds(1.5f);
        _image.DOFade(1, 2f);
        yield return new WaitForSeconds(3.5f);
        _sceneChanger.SceneChanger("InGame");
    }
}
