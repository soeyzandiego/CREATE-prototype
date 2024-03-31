using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFOUR : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody rb;
    RotateCamera focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = FindObjectOfType<RotateCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }
}
