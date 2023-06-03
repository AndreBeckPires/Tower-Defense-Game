using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class WaveSpawner : MonoBehaviour
{



    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public Text waveCountdownText;

    public float timeBetweenWaves;
    private float countdown = 2f;

    private int waveIndex = 0;


    void Start()
    {
        countdown = timeBetweenWaves;
    }
    void Update()
    {

        if(EnemiesAlive > 0)
        {
            return;
        }
        if(countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves; //depois de triggar a primeira começa o "loop" de waves
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = Mathf.Round(countdown).ToString();//corta decimais
    }

    IEnumerator spawnWave()//coroutine que pode ser pausada
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.rate);//spawnna um, espera e spawna o proximo da wave
        }
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("level finished");
            this.enabled = false;

        }

    }

    void spawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//spawn method
        EnemiesAlive++;
    }
}
