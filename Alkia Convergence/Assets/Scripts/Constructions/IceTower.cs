using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Construction
{

    // Start is called before the first frame update
    public GameObject iceBulletGo;
    public GameObject generatorBullets;
    private Character targetCharacter;
    public float timeStunedEffectBullet;
    public float speedRotateTower;
    public float delayShoot;
    protected float auxDelayShoot;
    public RangeDetectedEnemy rangeDetectedEnemy;
    public bool enableRotate = true;
    public bool changeTargetForHit;
    [HideInInspector]
    public bool enableShoot;
    protected override void Start()
    {
        base.Start();
        enableShoot = false;
        auxDelayShoot = delayShoot;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckTarget();
        CheckDelayShoot();
    }
    public void CheckDelayShoot()
    {
        if (enableShoot)
        {
            if (delayShoot <= 0)
            {
                Shoot();
                delayShoot = auxDelayShoot;
            }
            else
            {
                delayShoot = delayShoot - Time.deltaTime;
            }
        }
        else
        {
            delayShoot = auxDelayShoot;
        }
    }

    public void Shoot()
    {
        IceBullet refIceBullet = null;
        refIceBullet = Instantiate(iceBulletGo, generatorBullets.transform.position, iceBulletGo.transform.rotation).GetComponent<IceBullet>();
        if(refIceBullet != null)
        {
            refIceBullet.shooter = this;
            refIceBullet.damage = damage;
            refIceBullet.team = team;
            refIceBullet.ShootRight(generatorBullets);
        }
    }
    public void HitShoot()
    {
        if (changeTargetForHit)
        {
            targetCharacter = null;
        }
    }
    public void CheckTarget()
    {
        targetCharacter = rangeDetectedEnemy.GetTargetCharacter();
        if (targetCharacter != null)
        {

            enableShoot = true;
            //Debug.Log("ENTRE");
            Vector2 direction = Vector2.zero;
            if (enableRotate)
            {
                direction = targetCharacter.transform.position - transform.position;
            }
            else
            {
                direction = targetCharacter.transform.position - generatorBullets.transform.position;
            }
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotateTower * Time.deltaTime);
        }
        else
        {
            enableShoot = false;
        }
    }
}
