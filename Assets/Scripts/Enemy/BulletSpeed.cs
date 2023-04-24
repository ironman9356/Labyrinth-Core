using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Bullet;
    public float bulletSpeed = 5f;
    GameObject Player;
    Vector3 playerPos;


    // Update is called once per frame
    void Start()
    {
        Bullet = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = Player.transform.position;
        Vector3 direction = playerPos - Bullet.transform.position;
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.AngleAxis(rot - 90, Vector3.forward);
        Bullet.velocity = direction.normalized * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            //Destroy(collision.gameObject);
        }
    }

}
