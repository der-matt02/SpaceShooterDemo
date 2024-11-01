using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public float initialSpeed = 5f;       // Velocidad inicial de la bala
    public float accelerationForce = 10f; // Fuerza de aceleración aplicada a la bala
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Establecer la velocidad inicial de la bala en la dirección "hacia adelante"
        rb.velocity = transform.up * initialSpeed;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Aplicar una aceleración continua en la dirección "hacia adelante" cada frame
        rb.AddForce(transform.up * accelerationForce * Time.deltaTime, ForceMode2D.Force);

    }
}
