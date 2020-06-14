using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lib de C#
using System;
public class Enemy : MonoBehaviour
{

    //HACER QUE EL OnDieEnemy Detecte que player lo mato.




    //HACER QUE EL OnDieEnemy Detecte que player lo mato.





    //HACER QUE EL OnDieEnemy Detecte que player lo mato.




    // Start is called before the first frame update
    public float life = 5;
    public static event Action<Enemy> OnDieEnemy; // esto es un Action que es como un delegate pero mas pro.
    // Update is called once per frame
    void Update()
    {
        life = life - Time.deltaTime;
        CheckDie();
    }
    void CheckDie()
    {
        if (life <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if(OnDieEnemy != null)
        {
            OnDieEnemy(this);
        }
        Destroy(gameObject);
    }
}
