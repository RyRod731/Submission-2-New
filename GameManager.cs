using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject[] thingsThatSpawn;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnSomething", 2f, 3f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: 3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++) 
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    void SpawnSomething()
    {
        int tempInt;
        tempInt = Random.Range(0, 3);
        Instantiate(thingsThatSpawn[tempInt], new Vector3(Random.Range(-8f, 8f), Random.Range(-7f, 7f), 0), Quaternion.identity);

    }

    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LivesChange(int currentLife)
    {
        livesText.text = "Lives: " + currentLife;
    }
}
