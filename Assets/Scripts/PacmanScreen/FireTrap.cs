using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private GameManager gameManager;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if(!triggered)
            {
                StartCoroutine(ActivateTrap());
            }

            if (active)
            {
                gameManager.ReduceLive();
            }
        }
    }

    private IEnumerator ActivateTrap()
    {
        triggered = true;
        spriteRenderer.color = Color.red; //turn to red to notify player
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("active", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("active", false);
    }
}

