using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullets;
    public Transform initialPos;
    public GameObject spark;
    public float Time2Shoot = 0.3f;
    public float bulletPower;

    private float time2Shoot;

    private void Update()
    {
        RotateGun();
        time2Shoot -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time2Shoot < 0)
        {
            Shooting();

        }
    }
    private void RotateGun()
    {
        //get mouse position to rotate gun
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerToMouse = mousePos - transform.position;
        float angle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
    private void Shooting()
    {
        time2Shoot = Time2Shoot;

        GameObject bullet = Instantiate(bullets, initialPos.position, Quaternion.identity);

        Instantiate(spark, initialPos.position, transform.rotation, transform);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletPower, ForceMode2D.Impulse);
    }
}
