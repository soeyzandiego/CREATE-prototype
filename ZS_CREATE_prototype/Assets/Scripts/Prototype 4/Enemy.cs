using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    Rigidbody rb;
    PlayerControllerFOUR player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerControllerFOUR>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);
    }
}
