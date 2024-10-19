using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameWinFinal gameWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            gameWin.Setup(GameManager.currentScores);
            Destroy(collision.gameObject);
        }
    }
}
