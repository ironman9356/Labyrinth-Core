using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpeed : MonoBehaviour
{
    Rigidbody2D Bullet;
    public float bulletSpeed = 5f;
    GameObject shootPoint;

    float timer;

    void Start()
    {
        Bullet = GetComponent<Rigidbody2D>();
        shootPoint = GameObject.FindGameObjectWithTag("shootPoint");
        Vector3 shootDir = Input.mousePosition - Camera.main.WorldToScreenPoint(shootPoint.transform.position);
        var angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Bullet.velocity = shootDir.normalized * bulletSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10){
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

}
