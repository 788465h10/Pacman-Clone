
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }

    public GhostBehavior initial;
    public Transform pacman;
    public int points = 200;
    private void Awake()
    {
        this.movement = this.GetComponent<Movement>();
        this.home = this.GetComponent<GhostHome>();
        this.scatter = this.GetComponent<GhostScatter>();
        this.chase = this.GetComponent<GhostChase>();
        this.frightened = this.GetComponent<GhostFrightened>();
    }
    private void Start()
    {
        ResetState();
    }
    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        if(this.home != this.initial)
        {
            this.home.Disable();
        }
        if(this.initial != null)
        {
            this.initial.Enable();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.frightened.enabled)
            {
                FindAnyObjectByType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindAnyObjectByType<GameManager>().PacmanEaten();
            }
        }
    }
}
