using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    public float seconds = 2;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            BulletSpawnner();
        }
    }


    void BulletSpawnner()
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }


}
