using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float turnSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // turn vehicle ONLY if moving forward
        if (Mathf.Abs(forwardInput) > 0) { transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput); }
    }
}
