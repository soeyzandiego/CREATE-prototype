using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTWO : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField][Range(-25, 25)] float xRange = 15f;
    [SerializeField] GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // tutorial way
        //if (transform.position.x < -xRange)
        //{
        //    transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x > xRange)
        //{
        //    transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        //}

        // clamps x position
        if (Mathf.Abs(transform.position.x) > xRange)
        {
            transform.position = new Vector3(xRange * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(new Vector3(-xRange, 1, transform.position.z), new Vector3(xRange, 1, transform.position.z));
    }
}
