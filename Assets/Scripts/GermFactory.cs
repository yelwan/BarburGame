using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermFactory : MonoBehaviour
{
    [SerializeField] GameObject germPrefab;
    float randompos;
    Vector3 spawnPosition;
    public Transform shootingPosition1;
    public Transform shootingPosition2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void createGerm()

    {
        randompos = Random.Range(0, 2);
        if (randompos == 1) spawnPosition = shootingPosition1.position;
        else spawnPosition = shootingPosition2.position;
        //spawnPosition = new Vector3(randomX, 160.6f, 0f);
        GameObject c = null;
        if (germPrefab != null)
            Instantiate(germPrefab, spawnPosition, Quaternion.identity);

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
