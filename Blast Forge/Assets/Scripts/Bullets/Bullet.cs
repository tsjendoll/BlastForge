using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float lifeTime = .1f;
    [SerializeField] LayerMask whatIsSolid;
    
    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void FixedUpdate() 
    {
        

        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collided with an enemy
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            Destroy(collision.gameObject); // Destroy the enemy
            DestroyBullet();              // Destroy the bullet
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
