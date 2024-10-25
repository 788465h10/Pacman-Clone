using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    FinalLevelMusic finalLevelMusic;
    private void Awake()
    {
        finalLevelMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<FinalLevelMusic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            finalLevelMusic.PlayWinBackground();
            Destroy(collision.gameObject);
            Invoke("LoadGameWinBg", 4f);
        }
    }
    private void LoadGameWinBg()
    {
        SceneManager.LoadScene("Outtro");
    }
}
