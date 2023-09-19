using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public float speedIncrement = 0.2f;
    public int damageIncrement = 10;
    public int healthIncrement = 40;

    public GameObject[] WIN;
    public GameObject menu;
    private int currentLevel = 0;
    public GameObject EnemyPrefab;
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        POWERUP
    };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int waveIndex = 0;

    public Transform[] spawnPoints;
    private int spawnIndex = 0;

    public float timeBetweenWaves = 5.0f;
    private float waveCountdown;
    private float waveClearCheckCountdown = 1.0f;
    private SpawnState state = SpawnState.POWERUP;

    public GameObject powerUpStation;
    public Button button;
    public GameObject PlayerMenu;
    public GameObject WaveMenu;
    public GameObject PointMenu;


    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if all enemies are killed 
            if (WaveCleared())
            {
                //power up 
                state = SpawnState.POWERUP;
            }
            else
            {
                return;
            }
        }

        if(state == SpawnState.POWERUP)
        {
            if (waveIndex >= waves.Length)
            {
                foreach (GameObject w in WIN)
                {
                    w.SetActive(true);
                    menu.SetActive(true);
                }
            }
            powerUpStation.SetActive(true);
            WaveMenu.SetActive(true);
            PointMenu.SetActive(true);

            //reset 
            waveCountdown = timeBetweenWaves;

            button.onClick.AddListener(StartNextWave);
        }

        if (waveCountdown <= 0)
        {
            if (state == SpawnState.SPAWNING && WaveCleared())
            {                
                StartCoroutine(SpawnWave(waves[waveIndex]));
                EnemyPrefab.GetComponent<Enemy_Melee>().PowerUpEnemy(currentLevel);
                waveIndex++;
                currentLevel++;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void StartNextWave()
    {
        state = SpawnState.SPAWNING;
        powerUpStation.SetActive(false);
        WaveMenu.SetActive(false);
        PlayerMenu.SetActive(false);
        PointMenu.SetActive(false);
    }

    bool WaveCleared()
    {
        waveClearCheckCountdown -= Time.deltaTime;

        if (waveClearCheckCountdown <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                waveClearCheckCountdown = 1.0f;
                return true;
            }
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1.0f / _wave.spawnRate);
        }


        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {        
        GameObject enemy = Instantiate(_enemy, spawnPoints[spawnIndex].position, transform.rotation) as GameObject;
        enemy.GetComponent<EnemyBase>().speed += currentLevel * speedIncrement;
        enemy.GetComponent<EnemyBase>().damage += currentLevel * damageIncrement;
        enemy.GetComponent<Health>().maxHealth += currentLevel * healthIncrement;
        spawnIndex++;
        if(spawnIndex >= spawnPoints.Length)
        {
            spawnIndex = 0;
        }
    }
}
