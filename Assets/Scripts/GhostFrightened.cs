
using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer vulnerableState;
    public SpriteRenderer unVulnerableState;
    public bool eaten { get; private set; }
    public override void Enable(float duration)
    {
        base.Enable(duration);
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.vulnerableState.enabled = true;
        this.unVulnerableState.enabled = false;

        Invoke(nameof(ChangeState), duration / 2.0f);
    }
    public override void Disable()
    {
        base.Disable();
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.vulnerableState.enabled = false;
        this.unVulnerableState.enabled = false;
    }
    private void ChangeState()
    {
        if (!this.eaten)
        {
            this.vulnerableState.enabled = false;
            this.unVulnerableState.enabled = true;
            this.unVulnerableState.GetComponent<AnimatedSprite>().Restart();
        }
    }
    private void Eaten()
    {
        this.eaten = true;
        // loi dat ten bien nen kho doc, o duoi co 2 ref toi home, 
        // trong do home1 la ref toi GameObject GhostHome, con home2 la ref toi Transform cua home
        Vector3 position = this.ghost.home.home.position;
        position.z = this.ghost.transform.position.z;
        this.ghost.transform.position = position;

        this.ghost.home.Enable(this.duration);

        this.body.enabled = false;
        this.eyes.enabled = true;
        this.vulnerableState.enabled = false;
        this.unVulnerableState.enabled = false;
    }
    private void OnEnable()
    {
        this.ghost.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }
    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f;
        this.eaten = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }
}
