using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float minSpeed = 12;
    [SerializeField] float maxSpeed = 16;

    [Header("Torque")]
    [SerializeField] float minTorque = -10;
    [SerializeField] float maxTorque = 10;

    [Header("Spawn Position")]
    [SerializeField] float xSpawnRange = 4;
    [SerializeField] float ySpawnPos = -4;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    
    float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
