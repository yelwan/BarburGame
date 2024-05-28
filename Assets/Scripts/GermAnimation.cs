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
    public int germMag;


    [SerializeField] SpriteRenderer germRenderer;
    public GermFactory factory;
    private Sprite currentSprite;
    private int counter;
    public float switchTime = 0.5f; 
    void OnGUI(){
}
    void Start()
    {
        
        AllAnimSprites = new Sprite[][] { AnimSpritesP, AnimSpritesO, AnimSpritesG, AnimSpritesB, AnimSpritesR };
        counter = 0;
        germRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("SwitchSprite");
    }
    private IEnumerator SwitchSprite(){
        if (germMag > 0)
        {
            currentSprite = AllAnimSprites[germMag-1][counter++ % AllAnimSprites[germMag].Length];
            germRenderer.sprite = currentSprite;
        }
        else germRenderer.sprite = AnimSpritesBB;

        yield return new WaitForSeconds(switchTime);
	StartCoroutine("SwitchSprite");
}
   
}