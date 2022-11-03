using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
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
        public Transform enemy;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int waveIndex = -1;

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
            powerUpStation.SetActive(true);
            WaveMenu.SetActive(true);

            //reset 
            waveCountdown = timeBetweenWaves;

            button.onClick.AddListener(StartNextWave);
        }

        if (waveCountdown <= 0)
        {
            if (state == SpawnState.SPAWNING && WaveCleared())
            {
                waveIndex++;
                Debug.Log("Spawning Wave"); 
                if (waveIndex >= waves.Length)
                {
                    Debug.Log("Game Complete! Looping...");
                    waveIndex = 0;
                }
                StartCoroutine(SpawnWave(waves[waveIndex]));
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
        Debug.Log("Spawn Wave : " + _wave.name);
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1.0f / _wave.spawnRate);
        }


        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoints[spawnIndex].position, transform.rotation);
        spawnIndex++;
        if(spawnIndex >= spawnPoints.Length)
        {
            spawnIndex = 0;
        }
    }
}
