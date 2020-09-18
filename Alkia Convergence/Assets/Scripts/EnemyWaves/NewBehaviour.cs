using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviour : Character
{
    public float speed;
    private FSM FsmMinion;
    private Character target;
    [SerializeField]
    private MinionTravel AdvanceSystem;
    public enum MinionStates
    {
        Advancing,
        ChasingEnemy,
        Attacking,
        Count
    }
    public enum MinionEvents
    {
        TargetAcquired,
        EnemyInAttackRange,
        NoneEnemyInRange,
        Count
    }
    private void Awake()
    {
        speed = AdvanceSystem.speed;
        FsmMinion = new FSM((int)MinionStates.Count, (int)MinionEvents.Count, (int)MinionStates.Advancing);

        FsmMinion.SetRelations((int)MinionStates.Advancing, (int)MinionStates.ChasingEnemy, (int)MinionEvents.TargetAcquired);
        FsmMinion.SetRelations((int)MinionStates.ChasingEnemy, (int)MinionStates.Attacking, (int)MinionEvents.EnemyInAttackRange);
        FsmMinion.SetRelations((int)MinionStates.ChasingEnemy, (int)MinionStates.Advancing, (int)MinionEvents.NoneEnemyInRange);
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    
// Update is called once per frame
    protected override void Update()
    {
        //HAGO EL SWITCH DE LA MAQUINA DE ESTADOS
        switch (FsmMinion.GetCurrentState())
        {
            case (int)MinionStates.Advancing:
                Advance();
                break;
            case (int)MinionStates.ChasingEnemy:
                Chase();
                EnemyOnRange();
                break;
            case (int)MinionStates.Attacking:
                Attack();
                break;
           
        }
    }
    public void Advance()
    {
        AdvanceSystem.FollowDefaultPath();
    }
    public void Attack()
    {
        if (target != null)
        {
            target.currentLife = (target.currentLife + target.defense) - damage;
        }
    }
    public void Chase()
    {
        if (target != null)
        {      
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    private void EnemyOnRange()
    {
        if (target != null)
        {           
            Vector2 Distance = transform.position - target.transform.position;
            if (Distance.magnitude < 0.5f)
            {
                FsmMinion.SendEvent((int)MinionEvents.EnemyInAttackRange);
                Chase();
            }            
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent <Character>();
        if (character==null)
        {
            return;
        }

        if (character.team!=this.team)
        {
            target = character;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character == null)
        {
            return;
        }
        if (character==target)
        {
            target = null;
            FsmMinion.SendEvent((int)MinionEvents.NoneEnemyInRange);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    
}
