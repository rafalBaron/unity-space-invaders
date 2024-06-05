using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text levelText;
    public Image[] hearts;
    public Text score;
    public Text ammo;

    void Update()
    {
        levelText.text = "Level: " + GameManager.Instance.level;
        score.text = "Score: " + GameManager.Instance.score;
        ammo.text = GameManager.Instance.ammo.ToString();

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < GameManager.Instance.health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
