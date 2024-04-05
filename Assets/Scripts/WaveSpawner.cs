using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class WaveSpawner : MonoBehaviour
{

    public GameObject nextEnemy;

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;


    public Text waveCountdownText;


    public float timeBetweenWaves;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameManager gameManager;

    public int TESTE;
    public AudioSource audioEndGame;

    public bool isActive;
    public Text nWaveText;


    public bool stopSpawnWave = false;
    public int currentWaveCount;

    string nomePrefab;
    void Awake()
    {
        timeBetweenWaves = 5f;
        countdown = timeBetweenWaves;
      
        nWaveText.gameObject.SetActive(true);
        updateWaveCounter();
    }
    void Update()
    {
        isActive = nWaveText.gameObject.activeSelf;
       
     
        if (EnemiesAlive > 0)
        {
            return;
        }
        if(countdown <= 0f)
        {
           
            updateWaveCounter();
            stopSpawnWave = false;
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves; //depois de triggar a primeira começa o "loop" de waves
            updateNextEnemy();
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = "Proxima onda: " +  Mathf.Round(countdown).ToString();//corta decimais


        if (waveIndex == waves.Length && EnemiesAlive == 0)
        {
            audioEndGame.Play(0);
            gameManager.WinLevel();
            this.enabled = false;

        }

        
    }

    IEnumerator spawnWave()//coroutine que pode ser pausada
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            if (stopSpawnWave)
            {
                waveIndex = 0;
                yield break; // Interrompe imediatamente se stopSpawnWave for true
            }


            spawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.rate);//spawnna um, espera e spawna o proximo da wave
        }
        waveIndex++;

     

    }

    void spawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//spawn method
      
    }

    void updateWaveCounter()
    {
        nWaveText.text = "Ondas: " + (waves.Length - waveIndex).ToString();
    }

    public void reset()
    {
        waveIndex = 0;
        stopSpawnWave = true;
        StopCoroutine(spawnWave());
        timeBetweenWaves = 5f;
        countdown = timeBetweenWaves;
        EnemiesAlive = 0;
        nWaveText.gameObject.SetActive(true);
        updateWaveCounter();
        
        StopCoroutine(spawnWave());
     
}

    void updateNextEnemy()
    {

        {
            if (waveIndex + 1 < waves.Length)
            {
                nomePrefab = waves[waveIndex + 1].enemyPrefab.name;
            }
            if (nomePrefab == "Enemy")
            {
                nextEnemy.GetComponent<ShowNextEnemy>().changeImage(0);
            }
            if (nomePrefab == "Enemy 2")
            {
                nextEnemy.GetComponent<ShowNextEnemy>().changeImage(1);
            }
        }
    }
}
