using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [System.Obsolete]
    public void RestartGame()
    {

        GameManager.Instance.health = 3;
        GameManager.Instance.level = 1;
        GameManager.Instance.score = 0;
        GameManager.Instance.pointsSinceLevelUp = 0;
        GameManager.Instance.ammo = 20;

        SceneManager.LoadScene("SampleScene");

        Time.timeScale = 1f;

        GameManager.Instance.gameOverCanvas.SetActive(false);

    }
}
