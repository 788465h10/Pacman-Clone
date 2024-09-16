using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    //more ghost you eat, more points you get
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }
    public TMP_Text scoreText;
    public Image healthCurrent;
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        scoreText.text = "Score: 0";
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
        ResetGhostMultiplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }
        this.pacman.ResetState();
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
        healthCurrent.fillAmount = this.lives / 10.0f;
    }
    public void GhostEaten(Ghost ghost)
    {
        int pointForGhost = ghost.points * this.ghostMultiplier;
        SetScore(this.score + pointForGhost);
        this.ghostMultiplier++;
    }
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(RestState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }
    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false); //hide pellet
        SetScore(this.score + pellet.points);
        scoreText.text = "Score: " + this.score.ToString();
        if (!IsPelletRemaining())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }
    public void PowerPelletEaten(PowerPellet powerPellet)
    {
        for (int i = 0; i<this.ghosts.Length; i++)
        {
            this.ghosts[i].frightened.Enable(powerPellet.duration);
        }
        PelletEaten(powerPellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), powerPellet.duration);
    }
    private bool IsPelletRemaining()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }

}
