        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.SceneManagement;
        using UnityEngine.UI;

        public class SceneManagement : MonoBehaviour
        {
            static public SceneManagement Instance;
            public Text winnerText;
            public Button nextLevelButton;
            public Image gameOverImage;
            public Sprite youWonSprite;
            public Sprite completedSprite;
            int scenecount = 3;
            int currentcount = 0;

    private void Start()
    {
        Instance = this;
        InitUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        InitUI();
        Time.timeScale = 1;
    }

    private void InitUI()
    {
        if (gameOverImage != null) gameOverImage.gameObject.SetActive(false);
        if (nextLevelButton != null)
        {
            nextLevelButton.gameObject.SetActive(false);
            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(LoadNextLevel);
        }
    }
    public void ShowGameOver(string winnerName)
            {

                if (currentcount < scenecount)
                {
                gameOverImage.gameObject.SetActive(true);
                gameOverImage.sprite = youWonSprite;
                nextLevelButton.gameObject.SetActive(true);
        }
                else if (currentcount == scenecount)
                {
                gameOverImage.gameObject.SetActive(true);
                gameOverImage.sprite = completedSprite;
                }
                winnerText.text = "Winner: " + winnerName;
                
            }

            private void LoadNextLevel()
            {
                int nextSceneIndex = ++currentcount;
                if (nextSceneIndex < scenecount)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }