using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] Text gameStatusText;
    [SerializeField] float gameDuration = 60f;
    [SerializeField] Text GameTime;
    [SerializeField] MouthObject Mouth;
    public Image gameOverImage;
    public Sprite youLostSprite;


    void Start()
    {
       
        gameStatusText.enabled = false;
        gameOverImage.gameObject.SetActive(false);
        gameStatusText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameDuration -= Time.deltaTime;
        GameTime.text = "Time: " + Mathf.Max(gameDuration, 0).ToString("0");
        CheckGameEnd();
    }
    void CheckGameEnd()
    {
        if (Mouth.CheckGameOver())
        {

            Time.timeScale = 0;
            gameStatusText.text = "Game Over";
            gameOverImage.gameObject.SetActive(true);
            gameOverImage.sprite = youLostSprite;
            gameStatusText.enabled = true;
            SceneManagement.Instance.restartLevelButton.gameObject.SetActive(true);
        }
        else if (gameDuration <= 0)
        {
            Time.timeScale = 0;
            gameStatusText.text = "You Won";
            gameStatusText.enabled = true;
            SceneManagement.Instance.ShowGameOver("Tissue Team");
            SceneManagement.Instance.nextLevelButton.gameObject.SetActive(true);
        }
    }
}
