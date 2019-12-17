using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float speed;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject bulletExplosion;

    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.y > screenBounds.y * 1.1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    { 
        EnemyAttributes enemy = hitInfo.GetComponent< EnemyAttributes >();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            GameObject bulletEffect = Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletEffect, 1);
        }
    }

}
