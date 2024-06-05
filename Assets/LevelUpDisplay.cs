using UnityEngine;
using UnityEngine.UI;

public class LevelUpDisplay : MonoBehaviour
{
    [SerializeField] private Text levelUpText;
    private float displayTime = 3f;
    private float elapsedTime = 0f;
    private void Start()
    {
        levelUpText.gameObject.SetActive(false);
    }

    public void ShowLevelUp()
    {
        levelUpText.gameObject.SetActive(true);
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (levelUpText.gameObject.activeSelf)
        {
            elapsedTime += Time.deltaTime;

            levelUpText.color = (elapsedTime % 0.4f < 0.2f) ? Color.white : Color.red;

            if (elapsedTime >= displayTime)
            {
                levelUpText.gameObject.SetActive(false);
            }
        }
    }
}