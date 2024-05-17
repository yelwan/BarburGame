using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GermCorutineManager : MonoBehaviour
{
    private bool canShoot = true;
    private bool isSpawning = false;
    [SerializeField] GermFactory germFactory;
    [SerializeField] Text countdownTextUI;
    public Collider2D spawningArea;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootGermsCoroutine());
    }
    IEnumerator ShootGermsCoroutine()
    {
        while (true)
        {
            if (canShoot && !isSpawning)
            {
                if (countdownTextUI != null)
                {
                    isSpawning = true;
                    applyCountdownText("5");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("4");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("3");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("2");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("1");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("Germ Attack");
                    yield return new WaitForSeconds(1f);
                    if (spawningArea != null)
                    {
                        germFactory.createGerm();
                        isSpawning = false;
                    }
                }
                yield return null;
            }
        }
    }
    void applyCountdownText(string i_text)
    {
        if (countdownTextUI == null) return;
        countdownTextUI.text = i_text;
    }
}
