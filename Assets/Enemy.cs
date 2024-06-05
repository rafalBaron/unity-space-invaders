using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 0.5f;
    public GameObject explosionPrefab;
    public Camera mainCamera;
    public AudioSource explosion;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.Instance.AddScore(1);
            explosion.Play();
        }
    }
}
