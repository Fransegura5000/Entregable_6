using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 1f;
    private float repeatRate = 1.5f;
  
    private float spawnPos;
    private float randomHeight;

    private Vector3 randomPos;

    private float limY = 13f;

    public GameObject[] obstaclePrefabs;
    private PlayerController playerControllerScript;
 

    
    void Start()
    {
        // Repetimos la función SpawnObstacle cada 1.5 segundos y empieza en 1 segundo
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public void SpawnObstacle()
    {
        // con esta variable hacemos que aparezcan los objetos en una posición aleatoria tanto en el eje Y como en el lado derecho o izquierdo 
        
        if (!playerControllerScript.gameOver)
        {
            randomHeight = Random.Range(-limY, limY);
            spawnPos = Random.Range(0, 2);

            if (spawnPos == 0)
            {
                randomPos = new Vector3(-13, randomHeight, 0);
                Instantiate(obstaclePrefabs[1], randomPos, obstaclePrefabs[1].transform.rotation);
            }

            if (spawnPos == 1)
            {
                randomPos = new Vector3(13, randomHeight, 0);
                Instantiate(obstaclePrefabs[0], randomPos, obstaclePrefabs[0].transform.rotation);
            }

           
            
          
            
        }
    }
}
