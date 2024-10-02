using UnityEngine;

public class Time2Live : MonoBehaviour
{
    public float time;
    private void Start()
    {
        Destroy(this.gameObject, time);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
