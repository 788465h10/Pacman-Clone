using UnityEngine;

public class HealLive : MonoBehaviour
{
    GameManager gameManager;
    private float currentLives;
    private FunctionTimer functionTimer;
    private bool visible = true;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        functionTimer = new FunctionTimer(() =>
        {
            visible = !visible;
            this.gameObject.SetActive(visible);
        }, 2);
    }

    // Update is called once per frame
    void Update()
    {
        currentLives = gameManager.lives;
        functionTimer.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (currentLives < 3)
            {
                gameManager.IncreaseLive();
            }
            Destroy(this.gameObject);
        }
    }
}
