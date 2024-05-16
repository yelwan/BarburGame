using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FactoryAnimation : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] Renderer tissueRenderer;
    [SerializeField] InputManager inputManager;
    [SerializeField] Text tissueText;
    



    void Start()
    {
       

    }
    private void Awake()
    {
        inputManager.RegisterToInputEvents(StartCreation);

    }
    void Update()
    {
       

    }
    void StartCreation(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        if(NewMouseInputs==MouseInputs.OnMouseUp)
           StartObjectCreationCoroutine(3f);
    }

    private void StartObjectCreationCoroutine(float delaySeconds)
    {
        StartCoroutine(ObjectCreationCoroutine(delaySeconds));
    }

    private IEnumerator ObjectCreationCoroutine(float delaySeconds)
    {
        inputManager.SetIsCreatable(false);
        timer = delaySeconds;

        while (timer >= 0)
        {
            UpdateTimerText();
            UpdateTissueColor();
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }

        inputManager.SetIsCreatable(true);
    }
    private void UpdateTissueColor()
    {
        if (tissueRenderer != null)
        {
            float darkness = Mathf.Lerp(0f, 1f, 1f - (timer / 3f));
            tissueRenderer.material.color = new Color(darkness, darkness, darkness);
        }
    }
    private void UpdateTimerText()
    {
        if (tissueText != null)
        {
            tissueText.text = "Time Left: " + Mathf.Round(timer).ToString();
        }
    }

   


    
    

}
