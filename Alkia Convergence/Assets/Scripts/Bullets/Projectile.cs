using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMovement;
    public int damage;
    public Rigidbody2D rig2D;
    public void ShootUp()
    {
        rig2D.AddForce(transform.up * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
    public void ShootUp(GameObject generator)
    {
        rig2D.AddForce(generator.transform.up * speedMovement * Time.deltaTime, ForceMode2D.Impulse);
    }
}
