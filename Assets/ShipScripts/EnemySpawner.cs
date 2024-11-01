using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Aseg�rate de que el GameObject tenga un Rigidbody2D
public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Arreglo de prefabs de enemigos
    public float spawnRangeX = 8f;     // Rango en el eje X para la aparici�n de enemigos
    public float spawnY = 6f;          // Posici�n en Y donde aparecen los enemigos (parte superior)
    public float minSpawnDelay = 1f;   // M�nimo tiempo de espera para el spawn de enemigos
    public float maxSpawnDelay = 3f;   // M�ximo tiempo de espera para el spawn de enemigos

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D al iniciar el juego
        rb.gravityScale = 0; // Asegurarse de que la gravedad no afecte al spawner
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Tiempo de espera aleatorio entre apariciones
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            // Selecci�n aleatoria del prefab de enemigo y de la posici�n en X
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            // Instanciar el enemigo en la posici�n aleatoria
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
