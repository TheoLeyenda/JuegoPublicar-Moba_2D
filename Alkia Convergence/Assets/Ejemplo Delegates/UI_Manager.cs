using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textScore;
    void Start()
    {
        textScore.text = "Score: ";
    }
    void OnEnable()
    {
        Player.OnKillEnemy += CheckTextScore;
    }
    void OnDisable()
    {
        Player.OnKillEnemy -= CheckTextScore;
    }

    void CheckTextScore(Player p)
    {
        textScore.text = textScore.text + p.scoreForKillEnemy;
    }
}
