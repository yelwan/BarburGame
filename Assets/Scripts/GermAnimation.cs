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
    Sprite[][] AllAnimSprites;


    [SerializeField] SpriteRenderer germRenderer;
    public GermFactory factory;
    private Sprite currentSprite;
    private int counter;
    private int germMag;
    public float switchTime = 0.5f; 
    void OnGUI(){
}
    void Start()
    {
         germMag = Random.Range(0, 2);
        AllAnimSprites = new Sprite[][] { AnimSpritesG, AnimSpritesR, AnimSpritesP, AnimSpritesO, AnimSpritesB };
        counter = 0;
        germRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("SwitchSprite");
    }
    private IEnumerator SwitchSprite(){
	currentSprite = AllAnimSprites[germMag][counter++ % AllAnimSprites[germMag].Length];
    germRenderer.sprite = currentSprite;
	yield return new WaitForSeconds(switchTime);
	StartCoroutine("SwitchSprite");
}
   
}