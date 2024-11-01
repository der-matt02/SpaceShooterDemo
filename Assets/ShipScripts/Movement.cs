using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                   // Velocidad de movimiento de la nave
    private Rigidbody2D rb;                        // Referencia al Rigidbody2D

    public GameObject bulletPrefab;                // Prefab de la bala
    public Transform[] shootingPoints;             // Array de puntos de disparo

    void Start()
    {
        // Obtener el componente Rigidbody2D al iniciar el juego
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener el input de las teclas WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Crear un vector de movimiento en función del input
        Vector2 move = new Vector2(moveX, moveY) * moveSpeed;

        // Asignar velocidad al Rigidbody2D para mover la nave
        rb.velocity = move;

        // Disparar al presionar la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar una bala en cada punto de disparo
        foreach (Transform shootingPoint in shootingPoints)
        {
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        }
    }
}
