using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedChest;
    public Sprite closedChest;

    private bool isOpened = false;
    private bool isTriggered = false;

    public TMP_Text suggestionText;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            isTriggered = true;
            suggestionText.gameObject.SetActive(true);
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
        }
    }
    private void OpenChest()
    {
        spriteRenderer.sprite = openedChest;
        isOpened = true;
    }
}
