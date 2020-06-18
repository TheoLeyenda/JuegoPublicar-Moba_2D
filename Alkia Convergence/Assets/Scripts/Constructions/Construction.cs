using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public int maxLife;
    public int life;
    public int damage;
    public Character.TeamCharacter team;
    protected Vector3 initialPosition;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = initialPosition;
    }

}
