using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTHREE : MonoBehaviour
{
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float gravityModifier;

    [Header("Particles")]
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;

    [Header("Audio")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip crashSound;

    // component references
    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;

    bool grounded;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            grounded = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        { 
            gameOver = true; 
            Debug.Log("Game Over");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSound);
        }
    }

    public bool GameOver() { return gameOver; }
}
