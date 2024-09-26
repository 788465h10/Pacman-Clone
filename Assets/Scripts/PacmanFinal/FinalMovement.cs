using UnityEngine;

public class FinalMovement : MonoBehaviour
{
    public float moveSpeed = 25f;
    public float rollBoost = 10f;
    private float rollTime;
    public float RollTime;
    bool rollOnce = false;

    public Animator animator;

    public Vector3 moveInput;

    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("speed", moveInput.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("rool", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
        }

        if (rollTime <= 0 && rollOnce == true)
        {
            animator.SetBool("rool", false);
            moveSpeed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                spriteRenderer.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                spriteRenderer.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
    }
}
