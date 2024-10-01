using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    public float speed = 10f;

    private float distance;

    private void Awake()
    {
        target = GameObject.Find("Pacman");
    }

    private void Update()
    {
        //divide movement of ranged and melee enemy (thinking)

        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Destroy(collision.gameObject);
            target = null;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
