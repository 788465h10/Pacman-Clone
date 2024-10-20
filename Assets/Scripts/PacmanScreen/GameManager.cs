using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOver gameOver;
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    //more ghost you eat, more points you get
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }
    public TMP_Text scoreText;
    public Image healthCurrent;
    public PauseMenu pauseMenu;
    public static int currentScores, currentLives;

    NormalLevelMusic normalLevelMusic;
    private void Awake()
    {
        normalLevelMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<NormalLevelMusic>();
    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        if (SceneManager.GetActiveScene().name == "Pacman")
        {
            SetScore(0);
            SetLives(3);
        }
        else
        {
            SetScore(currentScores);
            //SetLives(currentLives);
            SetLives(3);
        }

        scoreText.text = "Score: " + score.ToString();
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
        normalLevelMusic.StopBackground();
        gameOver.Setup(this.score);
    }
    public void ReduceLive()
    {
        SetLives(this.lives - 1);
    }
    public void IncreaseLive()
    {
        SetLives(this.lives + 1);
    }
    private void SetScore(int score)
    {
        this.score = score;
    }
    private void SetLives(int lives)
    {
        this.lives = lives;
        healthCurrent.fillAmount = this.lives / 10.0f;
        if (this.lives <= 0)
        {
            GameOver();
        }
    }
    public void GhostEaten(Ghost ghost)
    {
        int pointForGhost = ghost.points * this.ghostMultiplier;
        normalLevelMusic.PlaySFX(normalLevelMusic.eatGhost);
        SetScore(this.score + pointForGhost);
        this.ghostMultiplier++;
    }
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        normalLevelMusic.PlaySFX(normalLevelMusic.death);
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
        //press esc to pause game
        if(Input.GetKeyDown("escape"))
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        //if game over, press space to start new game at level 1
        if (this.lives <= 0 && Input.GetKeyDown("space"))
        {
            gameOver.gameObject.SetActive(false);
            SceneManager.LoadScene("Pacman");
            //NewGame();
        }
        //if you win, move to next level
        if (this.lives > 0 && !IsPelletRemaining())
        {
            currentScores = this.score;
            currentLives = this.lives;
            Invoke(nameof(LoadNextLevel), 3.0f);
        }
    }
    private void LoadNextLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Pacman":
                SceneManager.LoadScene("Pacman1");
                break;
            case "Pacman1":
                SceneManager.LoadScene("Pacman2");
                break;
            case "Pacman2":
                SceneManager.LoadScene("Pacman3");
                break;
            case "Pacman3":
                SceneManager.LoadScene("PacmanFinal");
                break;
            default:
                break;
        }
    }
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false); //hide pellet
        normalLevelMusic.PlaySFX(normalLevelMusic.eatPellet);
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
        normalLevelMusic.PlaySFX(normalLevelMusic.powerPelletDuration);
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
