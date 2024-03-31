using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFOUR : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float powerupStrength = 15f;
    [SerializeField] GameObject powerupIndicator;

    Rigidbody rb;
    RotateCamera focalPoint;
    bool hasPowerUp = false;
    Vector3 powerupOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = FindObjectOfType<RotateCamera>();
        powerupOffset = powerupIndicator.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicator.transform.position = transform.position + powerupOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDir = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRB.AddForce(forceDir * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7f);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }
}
