using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public GameObject audioS;
    public AudioSource audioEndGame;
    bool ended = false;

    void Start()
    {
        audioS = GameObject.Find("dTakenAudio");
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    void Update()
    {
        if (Lives <= 0 && ended == false)
        {
            audioEndGame.Play(0);
            ended = true;
        }
        if(Lives < 0)
        {
            Destroy(audioS);
        }
    }

}
