using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public int score { get; private set; }
    public int lives { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }
    private void NewRound()
    {
        foreach (Transform pellets in this.pellets)
        {
            pellets.gameObject.SetActive(true);
        }
        RestState();
    }
    private void RestState()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }
        this.pacman.gameObject.SetActive(true);
    }
    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }
    private void SetScore(int score)
    {
        this.score = score;
    }
    private void SetLives(int lives)
    {
        this.lives = lives;
    }
    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
    }
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if(this.lives > 0)
        {
            Invoke(nameof(RestState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }
}
