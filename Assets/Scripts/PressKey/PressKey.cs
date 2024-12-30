using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
