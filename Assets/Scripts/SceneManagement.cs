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
    public Button restartLevelButton;
    [SerializeField] MouthObject Mouth;
    int scenecount = 3;
    [SerializeField] int currentcount = 0;

    private void Start()
    {
        Instance = this;
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
        if (restartLevelButton != null)
        {
            restartLevelButton.gameObject.SetActive(false);
            restartLevelButton.onClick.RemoveAllListeners();
            restartLevelButton.onClick.AddListener(RestartLevel);
        }
    }
    public void ShowGameOver(string winnerName)
    {

        if (currentcount < scenecount)
        {
            gameOverImage.gameObject.SetActive(true);
            gameOverImage.sprite = youWonSprite;
        }

        winnerText.text = "Winner: " + winnerName;
    }

    private void LoadNextLevel()
    {

        if (currentcount < scenecount - 1)
        {
            currentcount++;
            SceneManager.LoadScene(currentcount);
        }
        else if (currentcount == scenecount - 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(currentcount);
    }
}