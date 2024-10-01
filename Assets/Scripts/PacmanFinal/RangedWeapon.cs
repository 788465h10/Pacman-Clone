using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject bullets;
    public Transform initialPos;
    public float Time2Shoot = 0.3f;
    public float bulletPower;

    //add distance to shoot (thinking)

    private float time2Shoot;

    private void Update()
    {
        time2Shoot -= Time.deltaTime;
        if (time2Shoot < 0)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        time2Shoot = Time2Shoot;

        GameObject bullet = Instantiate(bullets, initialPos.position, Quaternion.identity);

        GameObject player = GameObject.Find("Pacman");

        Vector3 direction = player.transform.position - transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction.x, direction.y) * bulletPower, ForceMode2D.Impulse);
    }
}
