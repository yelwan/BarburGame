using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryAnimation : MonoBehaviour
{
    static int totalEnergy = 10; 
    static float elapsedTime = 0f;
    const float energyIncrementInterval = 4f;
    private float timer = 0f;
    [SerializeField] Renderer tissueRenderer;
    [SerializeField] InputManager inputManager;
    [SerializeField] Text tissueText;
    private bool isCoroutineActive = false;
    [SerializeField] List<TissueObject> tissueObjects = new List<TissueObject>();

    private void Awake()
    {
        inputManager.RegisterToInputEvents(StartCreation);
    }
      private void Update () {
         foreach (TissueObject tissue in tissueObjects) {
            if (tissue.magnitude > totalEnergy) {
                 tissue.GetComponent<Renderer>().material.color = Color.black;
                 tissue.GetComponent<Collider2D>().enabled = false;
            }
            }
            Debug.Log(totalEnergy);
         }
    private void Start()
    {
        StartCoroutine(IncrementEnergyCoroutine());
    }

    void StartCreation(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        if (NewMouseInputs == MouseInputs.OnMouseUp && !isCoroutineActive)
            StartObjectCreationCoroutine(3f);
    }

    private void StartObjectCreationCoroutine(float delaySeconds)
    {
        StartCoroutine(ObjectCreationCoroutine(delaySeconds));
    }

    private IEnumerator ObjectCreationCoroutine(float delaySeconds)
    {
        isCoroutineActive = true;
        inputManager.SetIsCreatable(false);
        float creationTimer = delaySeconds;

        while (creationTimer > 0)
        {
            UpdateTimerText(creationTimer);
            UpdateTissueColor(creationTimer);
            yield return new WaitForSeconds(1f);
            creationTimer -= 1;
        }

        UpdateTimerText(creationTimer);
        UpdateTissueColor(creationTimer);
        inputManager.SetIsCreatable(true);
        isCoroutineActive = false;
    }

    private void UpdateTissueColor(float creationTimer)
    {
        if (tissueRenderer != null)
        {
            float darkness = Mathf.Lerp(0f, 1f, 1f - (creationTimer / 3f));
            tissueRenderer.material.color = new Color(darkness, darkness, darkness);
        }
    }

    private void UpdateTimerText(float creationTimer)
    {
        if (tissueText != null)
        {
            tissueText.text = "Time Left: " + Mathf.Round(creationTimer).ToString();
        }
    }

    public void HandleTissueDrop(TissueObject tissue)
    {
        DecrementEnergy(tissue.magnitude); 
    }

    private IEnumerator IncrementEnergyCoroutine()
    {
        float timer = 0;
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime>=energyIncrementInterval) {
                elapsedTime-=energyIncrementInterval;
                totalEnergy++;  
                EnableGermsUpToMagnitude(elapsedTime);
               timer++;
        }
        yield return null;
    }
    }
    private void DecrementEnergy(int magnitude)
    {
        totalEnergy -= magnitude;
    }

    private void EnableGermsUpToMagnitude(float second)
    {
        foreach (TissueObject tissue in tissueObjects)
        {
            if (tissue.magnitude > second) 
            {
                tissue.GetComponent<Renderer>().material.color = Color.white;
                tissue.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
  
    }


