using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed; // Velocidad de movimiento del enemigo

    void Start()
    {
        // Asignar una velocidad aleatoria al enemigo al iniciar
        moveSpeed = Random.Range(2f, 5f);
    }

    void Update()
    {
        // Mover el enemigo hacia abajo
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // Destruir al enemigo si sale de la pantalla por la parte inferior
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // Método para manejar colisiones con las balas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // Destruir tanto al enemigo como a la bala cuando colisionan
            Destroy(collision.gameObject); // Destruir la bala
            Destroy(gameObject);           // Destruir el enemigo
        }
    }
}
