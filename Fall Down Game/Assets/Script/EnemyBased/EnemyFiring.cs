using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{

    public Transform canon1;
    public GameObject laser;
    public float fireRate = 1f;
    public float nextFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject enemyLaser = Instantiate(laser, canon1.position, canon1.rotation);
            Destroy(enemyLaser, 10f);
        }
    }
}
