using UnityEngine;
using UnityEngine.UI;
public class PauseMusic : MonoBehaviour
{
    [SerializeField] Button soundButton;
    private bool musicPaused = false;
    [SerializeField ]AudioSource Background;
    [SerializeField] Sprite[] playPauseSprites;
    [SerializeField] Image soundimage;


    void Start()
    {
        soundimage.sprite = playPauseSprites[1];
        soundButton.onClick.AddListener(TaskOnClick);
        Background.Play();
    }

    void TaskOnClick()
    {
        musicPaused = !musicPaused;

        if (musicPaused)
        {
            Background.Pause();
            soundimage.sprite= playPauseSprites[0];
        }
        else
        {
            Background.UnPause();
            soundimage.sprite = playPauseSprites[1];
        }
    }
 
}