using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void SceneChanger(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }
}
