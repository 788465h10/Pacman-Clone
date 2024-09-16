
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Tunnel : MonoBehaviour
{
    public Transform connection;
    private void OnTriggerEnter2D(Collider2D pacman)
    {
        Vector3 pacman_position = pacman.transform.position;
        pacman_position.x = this.connection.position.x;
        pacman_position.y = this.connection.position.y;
        pacman.transform.position = pacman_position;
    }
}
