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

        private void Start()
        {
            gameOverImage.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            Instance = this;
        }

        public void ShowGameOver(string winnerName)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex < SceneManager.GetActiveScene().buildIndex)
            {
            gameOverImage.gameObject.SetActive(true);
            gameOverImage.sprite = youWonSprite;
            }
            else if (currentSceneIndex == SceneManager.GetActiveScene().buildIndex)
            {
            gameOverImage.gameObject.SetActive(true);
            gameOverImage.sprite = completedSprite;
            }
            winnerText.text = "Winner: " + winnerName;
            nextLevelButton.gameObject.SetActive(true);
            nextLevelButton.onClick.AddListener(LoadNextLevel);
        }

        private void LoadNextLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }