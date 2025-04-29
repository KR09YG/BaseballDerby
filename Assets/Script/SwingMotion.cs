using System.Collections;
using UnityEngine;

public class SwingMotion : MonoBehaviour
{
    [SerializeField] AudioSource _swingSe;
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
            _swingSe.Play();
            switch (_batting.Cursor.y)
            {
                case <= 1.7f:
                    _animator.SetTrigger("DownSwing");
                    Debug.Log("â∫");
                    break;
                case >= 2.5f:
                    _animator.SetTrigger("UpSwing");
                    Debug.Log("è„");
                    break;
                default:
                    _animator.SetTrigger("Swing");
                    Debug.Log("ê^ÇÒíÜ");
                    break;
            }
            StartCoroutine(SwingAnim());
        }
    }

    IEnumerator SwingAnim()
    {
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.position = new Vector3(-1.57f, 0f, -0.28f);
        yield return new WaitForSeconds(0.5f);
        _isSwing = false;
    }
}
