using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMovement;
    public int damage;
    public Rigidbody2D rig2D;
    public Character.TeamCharacter team;
    public float timeLife = 3;
    public float auxTimeLife;

    protected virtual void Start()
    {
        auxTimeLife = timeLife;
    }
    protected virtual void Update()
    {
        CheckTimeLife();
    }
    public void CheckTimeLife()
    {
        if (timeLife > 0)
        {
            timeLife = timeLife - Time.deltaTime;
        }
        else
        {
            timeLife = auxTimeLife;
            Destroy(gameObject);
        }
    }
    public void ShootUp()
    {
        rig2D.AddForce(transform.up * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
    public void ShootUp(GameObject generator)
    {
        rig2D.AddForce(generator.transform.up * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
    public void ShootRight(GameObject generator)
    {
        rig2D.AddForce(generator.transform.right * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
    public void ShootRight()
    {
        rig2D.AddForce(transform.right * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
}
