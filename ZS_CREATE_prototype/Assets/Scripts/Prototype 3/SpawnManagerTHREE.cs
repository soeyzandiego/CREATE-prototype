using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerTHREE : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Vector3 spawnPos = new Vector3(25, 0, 0);

    float startDelay = 2f;
    float repeatRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnPos, 1);
    }

    void SpawnObstacle()
    {
        if (FindObjectOfType<PlayerControllerTHREE>().GameOver() == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
