using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image _fadeImage;
    void Start()
    {
        _fadeImage = GetComponent<Image>();
        _fadeImage.DOFade(0, 0.5f);
    }
}
