using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject gameOverCanvas;
    public LevelUpDisplay levelUpDisplay;
    private EnemySpawner enemySpawner;
    public AudioSource levelUp;
    private MusicPlayer musicPlayer;
    public AudioSource gameOver;

    public int health = 3;
    public int level = 1;
    public int score = 0;

    public int ammo = 20;

    public int pointsToNextLevel = 10;
    public int pointsSinceLevelUp = 0;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        enemySpawner = FindObjectOfType<EnemySpawner>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameOverCanvas);
        DontDestroyOnLoad(levelUpDisplay);
        //DontDestroyOnLoad(enemySpawner);
        DontDestroyOnLoad(gameOver);
        DontDestroyOnLoad(levelUp);
        //DontDestroyOnLoad(musicPlayer);

    }

    public void takeAmmo()
    {
        this.ammo -= 1;
    }

    public void AddScore(int points)
    {
        this.score += points;

        pointsSinceLevelUp += points;

        if (pointsSinceLevelUp >= pointsToNextLevel)
        {
            this.level++;
            pointsSinceLevelUp = 0;
            this.ammo = 20 + (this.level - 1) * 3;

            if (enemySpawner == null)
            {
                enemySpawner = FindObjectOfType<EnemySpawner>();
            }

            enemySpawner.AddMoreEnemies(0.1f);
            enemySpawner.AddSpeed(0.2f);
            levelUpDisplay.ShowLevelUp();
            levelUp.Play();
        }

    }

    public void TakeHealth()
    {
        this.health -= 1;
    }

    public void KillPlayer()
    {
        this.health = 0;
    }

    public void PlayGameOver()
    {
        gameOver.Play();
    }

    public void GameOver()
    {
        if (musicPlayer == null)
        {
            musicPlayer = FindObjectOfType<MusicPlayer>();
        }

        musicPlayer.MusicStop();

        Time.timeScale = 0f;

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

}
