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

    public Text waveCount;
    public GameObject waveCountObjectWithTag;
    public float timeBetweenWaves;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameManager gameManager;

    public int TESTE;
    public AudioSource audioEndGame;

    void Start()
    {
        countdown = timeBetweenWaves;
        waveCountObjectWithTag = GameObject.FindGameObjectWithTag("waveCountText");
        waveCount = waveCountObjectWithTag.GetComponent<Text>();
    }
    void Update()
    {

       
        if (EnemiesAlive > 0)
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


        if (waveIndex == waves.Length && EnemiesAlive == 0)
        {
            audioEndGame.Play(0);
            gameManager.WinLevel();
            this.enabled = false;

        }
        waveCount.text = (waves.Length - waveIndex).ToString();
    }

    IEnumerator spawnWave()//coroutine que pode ser pausada
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.rate);//spawnna um, espera e spawna o proximo da wave
        }
        waveIndex++;

     

    }

    void spawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//spawn method
      
    }
}
