using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lib de C#
using System;
public class Player : MonoBehaviour
{
    int score = 0;
    public int scoreForKillEnemy;

    public static event Action<Player> OnKillEnemy;
    // Start is called before the first frame update

    void OnEnable()
    {
        Enemy.OnDieEnemy += AddScoreForKillEnemy;
    }
    void OnDisable()
    {
        Enemy.OnDieEnemy -= AddScoreForKillEnemy;
    }
    void AddScoreForKillEnemy(Enemy e)
    {
        score = score + scoreForKillEnemy;
        Debug.Log("Puntaje: " + score);
        if(OnKillEnemy != null)
        {
            OnKillEnemy(this);
        }
    }
    // Update is called once per frame
    void Update(){}
}
