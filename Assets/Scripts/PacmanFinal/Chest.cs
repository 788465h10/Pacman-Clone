using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedChest;
    public Sprite closedChest;

    public bool isOpened = false;
    public bool isTriggered = false;

    public TMP_Text suggestionText;
    FinalLevelMusic finalLevelMusic;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChest;
        finalLevelMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<FinalLevelMusic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            isTriggered = true;
            if (!isOpened)
            {
                suggestionText.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            isTriggered = false;
            suggestionText.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (isTriggered && !isOpened && Input.GetKeyDown(KeyCode.F))
        {
            OpenChest();
            suggestionText.gameObject.SetActive(false);
        }
    }
    private void OpenChest()
    {
        spriteRenderer.sprite = openedChest;
        isOpened = true;
        finalLevelMusic.PlaySFX(finalLevelMusic.openChest);
    }
}
