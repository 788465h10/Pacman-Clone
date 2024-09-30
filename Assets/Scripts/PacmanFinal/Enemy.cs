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
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
