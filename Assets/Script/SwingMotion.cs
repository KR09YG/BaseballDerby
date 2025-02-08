using System.Collections;
using UnityEngine;

public class SwingMotion : MonoBehaviour
{
    Animator _animator;
    Batting _batting;
    bool _isSwing = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _batting = FindAnyObjectByType<Batting>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isSwing)
        {
            _isSwing = true;
            switch (_batting.Cursor.y)
            {
                case <= 1.7f:
                    _animator.SetTrigger("DownSwing");
                    Debug.Log("下");
                    break;
                case >= 2.5f:
                    _animator.SetTrigger("UpSwing");
                    Debug.Log("上");
                    break;
                default:
                    _animator.SetTrigger("Swing");
                    Debug.Log("真ん中");
                    break;
            }
            StartCoroutine(SwingAnim());
        }
    }

    IEnumerator SwingAnim()
    {
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.position = new Vector3(-1.810188f, 2.384186e-07f, -0.27777f);
        yield return new WaitForSeconds(0.5f);
        _isSwing = false;
    }
}
