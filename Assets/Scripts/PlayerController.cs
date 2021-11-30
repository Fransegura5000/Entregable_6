using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //                                                                               BALLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON
    public bool gameOver;
    private Rigidbody playerRigidbody;

    public ParticleSystem explosionParticleSystem;

    private AudioSource playerAudioSource;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    private float limY = 14f;               // Esta variable es para ajustar el limite en el eje Y.

    private float jumpForce = 12.5f;        // Esta variable será la potencia del salto del globo.
    private float topForce = 1;             // Esta variable es para que cuando toque el techo no quede pegado, sinó que baje instantaneo.
    private float gravityModifier = 2;      // Esta variable es para configurar la gravedad del objeto.

    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


            playerAudioSource.PlayOneShot(jumpClip, 1f);

        }


        if (transform.position.y > limY)
        {
            transform.position = new Vector3(transform.position.x, limY,
                transform.position.z);

            playerRigidbody.AddForce(Vector3.down * topForce, ForceMode.Impulse); 

        }

        if (transform.position.y < -limY)
        {
            Debug.Log("GameOver");

        }


    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        while (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Obstacle")) // con este comando hacemos que cuando el player colisione con un objeto con la etiqueta Obstacle, sale por consola un mensaje y se activa la variable gameOver
            {
                Debug.Log(message: "GAME OVER!");                // Mostrar por consola que has perdido

                gameOver = true;                                //La variable gameOver pasa a valer verdadero, para que el juego termine.

                Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);

                playerAudioSource.PlayOneShot(deathClip, 1f);


            }




        }
    }
}