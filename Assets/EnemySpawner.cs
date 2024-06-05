using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnInterval = 1f;
    private float spawnRangeX = 7f;
    private float enemySpeed = 0.4f;
    public Camera mainCamera;
    public AudioSource explosion;


    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }


    public void AddMoreEnemies(float x)
    {
        if (spawnInterval > 0.4)
        {
            spawnInterval -= x;
        }
    }

    public void AddSpeed(float speed)
    {
        enemySpeed += speed;
    }

    void SpawnEnemy()
    {
        print(enemySpeed);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
                                       Camera.main.ViewportToWorldPoint(Vector3.up).y,
                                       -1f);
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            enemy.GetComponent<Enemy>().SetSpeed(enemySpeed);

            StartCoroutine(CheckEnemyPosition(enemy));
        }
    }

    IEnumerator CheckEnemyPosition(GameObject enemy)
    {
        while (enemy != null)
        {
            Vector3 enemyScreenPosition = mainCamera.WorldToViewportPoint(enemy.transform.position);

            if (enemyScreenPosition.y < 0)
            {
                GameManager.Instance.TakeHealth();
                Destroy(enemy);
                explosion.Play();
                yield break;
            }

            yield return null;
        }
    }
}
