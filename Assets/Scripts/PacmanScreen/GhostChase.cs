
using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();
        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float mintoPacman = float.MaxValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 nextPosition = this.ghost.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.ghost.pacman.position - nextPosition).sqrMagnitude;

                if (distance < mintoPacman)
                {
                    mintoPacman = distance;
                    direction = availableDirection;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }
}
