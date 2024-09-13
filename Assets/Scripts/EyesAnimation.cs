using UnityEngine;

public class EyesAnimation : MonoBehaviour
{
    public Sprite eyesUp;
    public Sprite eyesDown;
    public Sprite eyesRight;
    public Sprite eyesLeft;

    public SpriteRenderer eyesRenderer { get; private set; }
    public Movement movement { get; private set; }
    private void Awake()
    {
        eyesRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<Movement>();
    }
    private void Update()
    {
        if (movement.direction == Vector2.up)
        {
            eyesRenderer.sprite = eyesUp;
        }
        else if (movement.direction == Vector2.down)
        {
            eyesRenderer.sprite = eyesDown;
        }
        else if (movement.direction == Vector2.right)
        {
            eyesRenderer.sprite = eyesRight;
        }
        else if (movement.direction == Vector2.left)
        {
            eyesRenderer.sprite = eyesLeft;
        }
    }
}
