using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTHREE : MonoBehaviour
{
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float gravityModifier; 

    Rigidbody rb;
    bool grounded;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = true; }
        else if (collision.gameObject.CompareTag("Obstacle")) { gameOver = true; Debug.Log("Game Over"); }
    }

    public bool GameOver() { return gameOver; }
}
