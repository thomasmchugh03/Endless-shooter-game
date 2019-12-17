using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
            GameObject bulletEffect = Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletEffect, 1);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
