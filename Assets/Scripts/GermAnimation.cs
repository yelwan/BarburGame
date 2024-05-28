using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GermAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] AnimSpritesG;
    [SerializeField] Sprite[] AnimSpritesR;
    [SerializeField] Sprite[] AnimSpritesP;
    [SerializeField] Sprite[] AnimSpritesO;
    [SerializeField] Sprite[] AnimSpritesB;
    [SerializeField] Sprite AnimSpritesBB;

    Sprite[][] AllAnimSprites;
    public int germMag=1;


    [SerializeField] SpriteRenderer germRenderer;
    private Sprite currentSprite;
    private int counter;
    public float switchTime = 0.5f;
    void OnGUI()
    {
    }
    void Start()
    {

        AllAnimSprites = new Sprite[][] { AnimSpritesP, AnimSpritesO, AnimSpritesG, AnimSpritesR, AnimSpritesB};
        counter = 0;
        germRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchSprite());
    }
    private IEnumerator SwitchSprite()
    {
        while (true)
        {
            if (germMag > 0 && germMag < AllAnimSprites.Length)
            {
                currentSprite = AllAnimSprites[germMag][counter++ % AllAnimSprites[germMag].Length];
                germRenderer.sprite = currentSprite;
            }
            else
            {
                currentSprite = AnimSpritesBB;
                germRenderer.sprite = currentSprite;
            }

            yield return new WaitForSeconds(switchTime);

        }

    }
}