using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // Destruir el enemigo al ser golpeado por una bala
            Destroy(gameObject);
        }
    }
}
 