using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] float gameDuration = 60f;
    [SerializeField] Text GameTime;
    [SerializeField] MouthObject Mouth;
    public Image gameOverImage;
    public Sprite youLostSprite;


    void Start()
    {
       
        gameOverImage.gameObject.SetActive(false);
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
            gameOverImage.gameObject.SetActive(true);
            AudioListener.pause = true;
            gameOverImage.sprite = youLostSprite;
            SceneManagement.Instance.restartLevelButton.gameObject.SetActive(true);
        }
        else if (gameDuration <= 0)
        {
            Time.timeScale = 0;
            SceneManagement.Instance.ShowGameOver("Tissue Team");
            SceneManagement.Instance.nextLevelButton.gameObject.SetActive(true);
        }
    }
}
