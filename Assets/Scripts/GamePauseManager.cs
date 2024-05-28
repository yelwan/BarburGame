
using UnityEngine;
using UnityEngine.UI;
public class GamePauseManager : MonoBehaviour
{
    [SerializeField] Button PauseButton;
    private bool GamePaused = false;
    [SerializeField] Sprite[] playPauseSprites;
    [SerializeField] Image pauseimage;


    void Start()
    {
        pauseimage.sprite = playPauseSprites[1];
        PauseButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GamePaused = !GamePaused;

        if (GamePaused)
        {
            Time.timeScale = 0;
            pauseimage.sprite = playPauseSprites[0];
            AudioListener.pause= true;
        }
        else
        {
            Time.timeScale = 1;
            pauseimage.sprite = playPauseSprites[1];
            AudioListener.pause = false;

        }
    }

}
