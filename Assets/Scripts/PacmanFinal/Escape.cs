using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameWinFinal gameWin;
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
            gameWin.Setup(GameManager.currentScores);
            Destroy(collision.gameObject);
        }
    }
}
