using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GermAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] AnimSprites;
    [SerializeField] SpriteRenderer germRenderer;
    public GermFactory factory;
    private Sprite currentSprite;
    private int counter;
    public float switchTime = 0.5f; 
    void OnGUI(){
}
    void Start()
    {
        counter = 0;
        germRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("SwitchSprite");
    }
    private IEnumerator SwitchSprite(){
	currentSprite = AnimSprites[counter++ % AnimSprites.Length];
    germRenderer.sprite = currentSprite;
	yield return new WaitForSeconds(switchTime);
	StartCoroutine("SwitchSprite");
}
   
}