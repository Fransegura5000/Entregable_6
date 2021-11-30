using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public float speed = 7f;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // con este if accedemos a la variable game over para ver si el juego ha de seguir en movimiento o pararse.
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
