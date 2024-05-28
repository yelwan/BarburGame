using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FactoryAnimation : MonoBehaviour
{

    static int totalEnergy = 5;
    static float elapsedTime = 0f;
    const float energyIncrementInterval = 4f; 
    private float timer = 0f;
    [SerializeField] Renderer tissueRenderer;
    [SerializeField] InputManager inputManager;
    private bool isCoroutineActive = false;
    [SerializeField] AudioSource creatableSound;
    [SerializeField] List<TissueObject> tissueObjects = new List<TissueObject>();

    private void Awake()
    {
        inputManager.RegisterToInputEvents(StartCreation);
    }
    private void Update()
    {
        foreach (TissueObject tissue in tissueObjects)
        {
            if (tissue.magnitude > totalEnergy)
            {
                tissue.GetComponent<Renderer>().material.color = Color.black;
                tissue.GetComponent<Collider2D>().enabled = false;
            }
        }
       // Debug.Log(totalEnergy);
    }
    private void Start()
    {
        StartCoroutine(IncrementEnergyCoroutine());
    }
    void StartCreation(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        if(NewMouseInputs==MouseInputs.OnMouseUp && !isCoroutineActive)
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
        timer = delaySeconds;

        while (timer > 0)
        {
            UpdateTissueColor();
            if (timer == 0) break; 
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
        UpdateTissueColor();
        inputManager.SetIsCreatable(true);
        creatableSound.Play();
        isCoroutineActive = false;
        
    }
    private void UpdateTissueColor()
    {
        if (tissueRenderer != null)
        {
            float darkness = Mathf.Lerp(0f, 1f, 1f - (timer / 3f));
            tissueRenderer.material.color = new Color(darkness, darkness, darkness);
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
            if (elapsedTime >= energyIncrementInterval && totalEnergy<5)
            {
                elapsedTime -= energyIncrementInterval;
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
    


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectedTissue : MonoBehaviour
{
    [SerializeField] Renderer tissueRenderer;
    private Color originalColor;
    private Color currentColor;
    private Collider2D myCollider;

    private void Start()
    {
        if (tissueRenderer != null)
        {
            originalColor = tissueRenderer.material.color;
            currentColor = originalColor;
        }
        myCollider = GetComponent<Collider2D>();  // Get the Collider2D component attached to the GameObject
    }

    private void Update()
    {
        DragAndDrop dragAndDrop = GetComponent<DragAndDrop>();
        if (dragAndDrop != null && tissueRenderer != null)
        {
            if (!dragAndDrop.IsDraggable || dragAndDrop.hasBeenDropped)
            {
                currentColor = originalColor;
            }
        }
        tissueRenderer.material.color = currentColor;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (tissueRenderer != null)
        {
            DragAndDrop dragAndDrop = GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                if (ColliderManager.Instance.colliders.Contains(collider)) {
                    currentColor = Color.green;
                }
                // Check if there are any other TissueObject colliders in the same area
                Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, myCollider.bounds.extents.magnitude);

                bool isOverlappingTissueObject = false;
                foreach (Collider2D overlappingCollider in overlappingColliders)
                {
                    if (overlappingCollider != myCollider && overlappingCollider.GetComponent<TissueObject>() != null)
                    {
                        isOverlappingTissueObject = true;
                        break;
                    }
                }

                if (isOverlappingTissueObject)
                {
                    currentColor = Color.red;
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
                currentColor = originalColor;
    }
}
 */