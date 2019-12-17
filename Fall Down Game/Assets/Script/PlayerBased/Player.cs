using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAttributes enemy = hitInfo.GetComponent<EnemyAttributes>();
        if (enemy != null)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
