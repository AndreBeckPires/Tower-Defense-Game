using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class WaveSpawner : MonoBehaviour
{

    public List<GameObject> gameObjectList = new List<GameObject>();

    public GameObject nextEnemy;

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public GameObject[] waveCounterIcons;
    public GameObject canvas;
    public float distanceIcons = 36;

    public Text waveCountdownText;


    public float timeBetweenWaves;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameManager gameManager;

    public int TESTE;
    public AudioSource audioEndGame;

    public bool isActive;
    //public Text nWaveText;


    public bool stopSpawnWave = false;
    public int currentWaveCount;

    string nomePrefab;


    public GameObject telaFinal;

    public bool audioPlayed;
    void Awake()
    {
        audioPlayed = false;
        timeBetweenWaves = 5f;
        countdown = timeBetweenWaves;
      
       // nWaveText.gameObject.SetActive(true);
        updateWaveCounter();
        for(int i =0; i < waves.Length; i++)
        {
            GameObject newObject = InstantiateAndAdd(waveCounterIcons[0]);


            distanceIcons += 36f;
        }
        Destroy(waveCounterIcons[1]);
    }


    void Update()
    {
        //isActive = nWaveText.gameObject.activeSelf;
       
     
        if (EnemiesAlive > 0)
        {
            return;
        }
        if(countdown <= 0f && EnemiesAlive <= 0)
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


        if (waveIndex == waves.Length && EnemiesAlive == 0 && !gameManager.isOver())
        {
            if(!audioPlayed)
            {
                audioEndGame.Play(0);
                audioPlayed = true;
            }
           this.enabled = false;
            gameManager.WinLevel();
            Invoke("TelaFinal", 1.5f);

        }

        
    }


    void TelaFinal()
    {
        telaFinal.SetActive(true);
       
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
      //  nWaveText.text = "Ondas: " + (waves.Length - waveIndex).ToString();
        DestroyLast();
    }

    public void reset()
    {
        waveIndex = 0;
        stopSpawnWave = true;
        StopCoroutine(spawnWave());
        timeBetweenWaves = 5f;
        countdown = timeBetweenWaves;
        EnemiesAlive = 0;
        //nWaveText.gameObject.SetActive(true);
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
            if (nomePrefab == "Enemy 4")
            {
                nextEnemy.GetComponent<ShowNextEnemy>().changeImage(2);
            }
            if(nomePrefab == "Enemy 3")
            {
                nextEnemy.GetComponent<ShowNextEnemy>().changeImage(3);
            }
        }
    }

    GameObject InstantiateAndAdd(GameObject prefab)
    {
        // Instancia o prefab
        GameObject newObj = Instantiate(prefab, new Vector3(waveCounterIcons[1].transform.position.x + distanceIcons, waveCounterIcons[1].transform.position.y, waveCounterIcons[1].transform.position.z), Quaternion.identity, canvas.transform);

        // Adiciona o novo objeto à lista
        gameObjectList.Add(newObj);

        return newObj;
    }

    void DestroyLast()
    {
        // Verifica se há pelo menos um objeto na lista
        if (gameObjectList.Count > 0)
        {
            // Pega o último objeto da lista
            GameObject lastObject = gameObjectList[gameObjectList.Count - 1];

            // Remove o último objeto da lista
            gameObjectList.RemoveAt(gameObjectList.Count - 1);

            // Destroi o último objeto
            Destroy(lastObject);
        }
        else
        {
            Debug.LogWarning("A lista está vazia. Não há objetos para destruir.");
        }
    }
}
