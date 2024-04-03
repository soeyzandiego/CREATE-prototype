using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    [SerializeField] float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }
}
