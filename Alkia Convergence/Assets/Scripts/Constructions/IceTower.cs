using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Construction
{

    // Start is called before the first frame update
    public IceBullet iceBullet;
    public GameObject generatorBullets;
    private Character targetCharacter;
    public float speedRotateTower;
    public RangeDetectedEnemy rangeDetectedEnemy;
    public bool enableRotate = true;
    private bool enableShoot;
    protected override void Start()
    {
        base.Start();
        enableShoot = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckTarget();
    }
    public void CheckTarget()
    {
        targetCharacter = rangeDetectedEnemy.GetTargetCharacter();
        if (targetCharacter != null)
        {
            Debug.Log("ENTRE");
            Vector2 direction = targetCharacter.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotateTower * Time.deltaTime);
           
        }
    }
}
