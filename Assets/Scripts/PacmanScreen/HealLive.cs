using System.Collections;
using UnityEngine;

public class HealLive : MonoBehaviour
{
    GameManager gameManager;
    private float currentLives;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;

    private bool visible = true;
    NormalLevelMusic normalLevelMusic;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        normalLevelMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<NormalLevelMusic>();
    }
    private void Start()
    {
        InvokeRepeating("hideHealLive", 3, 3);    
    }
    private void Update()
    {
        currentLives = gameManager.lives;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            normalLevelMusic.PlaySFX(normalLevelMusic.eatFruit);
            if (currentLives < 3)
            {
                gameManager.IncreaseLive();
            }
            Destroy(this.gameObject);
        }
    }
    private void hideHealLive()
    {
        if (!visible)
        {
            visible = true;
            this.gameObject.SetActive(true);
        }
        else
        {
            visible = false;
            this.gameObject.SetActive(false);
        }
    }

}
