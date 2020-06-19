using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Projectile
{
    // Start is called before the first frame update
    public IceTower shooter;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Hacer la colision contra el jugador/enemigo del otro equipo.
        Character OtherCollision = collider2D.gameObject.GetComponent<Character>();
        if (OtherCollision != null)
        {
            Debug.Log("ENTRE");
            if (OtherCollision.team.ToString() != team.ToString())
            {
                if (shooter != null)
                {
                    shooter.HitShoot();
                }
                OtherCollision.currentLife = OtherCollision.currentLife - damage;
                OtherCollision.state = Character.StateCharacter.Congelado;
                OtherCollision.delayStateCongelado = shooter.timeStunedEffectBullet;
                Destroy(gameObject);
            }
        }
        
    }
}
