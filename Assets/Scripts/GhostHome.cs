
using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform home;
    public Transform exithome;
    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(Exit());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.ghost.movement.SetDirection(-this.ghost.movement.direction);
        }
    }
    private IEnumerator Exit()
    {
        this.ghost.movement.SetDirection(Vector2.up, true);
        this.ghost.movement.rigidbody.isKinematic = true;
        this.ghost.movement.enabled = false;

        Vector3 position = this.transform.position;
        float duration = 0.5f;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.home.position, elapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0.0f;
        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.home.position, this.exithome.position, elapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
        this.ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.ghost.movement.rigidbody.isKinematic = false;
        this.ghost.movement.enabled = true;
    }
}
