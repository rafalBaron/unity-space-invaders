using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Camera mainCamera;
    public AudioSource shot;
    public AudioSource gameOver;

    void Update()
    {
        if (GameManager.Instance.health <= 0)
        {
            if (gameOver != null)
            {
                gameOver.Play();
            }
            else
            {
                print("GAME OVER NULL");
            }
            GameManager.Instance.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Space) && (GameManager.Instance.health > 0) && (GameManager.Instance.ammo > 0))
        {
            Shoot();
            GameManager.Instance.takeAmmo();
        }
    }

    void Shoot()
    {
        Vector3 firePointPosition = transform.position;

        GameObject projectile = Instantiate(projectilePrefab, firePointPosition, transform.rotation);

        projectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;

        StartCoroutine(CheckProjectilePosition(projectile));

        shot.Play();

    }

    IEnumerator CheckProjectilePosition(GameObject projectile)
    {
        while (projectile != null)
        {
            Vector3 projectileScreenPosition = mainCamera.WorldToViewportPoint(projectile.transform.position);

            if (projectileScreenPosition.y > 1)
            {
                Destroy(projectile);
                yield break;
            }

            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameOver.Play();
            GameManager.Instance.KillPlayer();
        }
    }
}