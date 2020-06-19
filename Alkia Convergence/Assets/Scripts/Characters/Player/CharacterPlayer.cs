using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    [Header("Datos Generales que se suman a tus skills al pasar de nivel")]
    protected int indexDataLevelUpCharacter;
    [System.Serializable]
    public class DataLevelUpCharacter
    {
        //Aqui van las estadisticas que se subiran del nivel de cada personaje
        //Estas estadisticas no se asignas sino que se suman a las que ya tenes
        public int addLife;
        public int addMana;
        public int addBasicDamage;
        public int addSkillDamage;
        public float addSpeedAttack;
        public float addSpeedMovement;
        public int addArmor;
        public float addValueRegenerationLife;
        public float addValueRegenerationMana;
        public float addCriticalPorcentage;
        public int addCriticalDamage;
        public float substractCoolDownBattle;

    }
    public enum TypeMovement
    {
        Position,
        Physics,
    }
    public int numberPlayer;
    public Rigidbody2D rigidbody2;
    public Animator animator;
    public TypeMovement typeMovement;
    [Header("Valor entre el 0 y el 1")]
    public float sensibilityController = 0.1f;

    [Header("Datos Generales del CharacterPlayer")]
    public int currentMana;
    public int maxMana;
    public int basicDamage;
    public int skillDamage; //Daño de habilidad
    public float speedAttack;
    public float speedMovement;
    public int currentLevel;
    public float currentXP;
    public int maxLevel;
    public int armor;
    public float valueRegenerationLife;
    public float valueRegenerationMana;
    public float criticalPorcentage;
    public int criticalDamage;
    public float cooldownBattle; // Reducción de enfriamiento(cooldown)

    protected override void Start()
    {
        base.Start();
        enableMovement = true;
        rigidbody2 = GetComponent<Rigidbody2D>();
        rigidbody2.velocity = Vector2.zero;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckAnimations();
        if (enableMovement)
        {
            switch (typeMovement)
            {
                case TypeMovement.Physics:
                    MovementPhysics();
                    break;
                case TypeMovement.Position:
                    MovementPositions();
                    break;
            }
        }

    }
    protected void CheckAnimations()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > sensibilityController)
            {
                animator.Play("WalkLeft");
            }
            if (Input.GetAxis("Horizontal") < -sensibilityController)
            {
                animator.Play("WalkRight");
            }
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > sensibilityController)
            {
                animator.Play("WalkUp");
            }
            if (Input.GetAxis("Vertical") < -sensibilityController)
            {
                animator.Play("WalkDown");
            }
        }
    }
    protected void MovementPositions()
    {
        bool right = Input.GetAxis("Horizontal") > sensibilityController;
        bool left = Input.GetAxis("Horizontal") < -sensibilityController;
        bool up = Input.GetAxis("Vertical") > sensibilityController;
        bool down = Input.GetAxis("Vertical") < -sensibilityController;
        rigidbody2.velocity = Vector2.zero;
        if (right)
        {
            transform.position = transform.position + new Vector3(transform.right.x * speedMovement * Time.deltaTime, 0, 0);
        }
        if (left)
        {
            transform.position = transform.position + new Vector3(-transform.right.x * speedMovement * Time.deltaTime, 0, 0);
        }
        if (up)
        {
            transform.position = transform.position + new Vector3(0, transform.up.y * speedMovement * Time.deltaTime, 0);
        }
        if (down)
        {
            transform.position = transform.position + new Vector3(0, -transform.up.y * speedMovement * Time.deltaTime, 0);
        }

    }
    protected void MovementPhysics()
    {
        bool right = Input.GetAxis("Horizontal") > sensibilityController;
        bool left = Input.GetAxis("Horizontal") < -sensibilityController;
        bool up = Input.GetAxis("Vertical") > sensibilityController;
        bool down = Input.GetAxis("Vertical") < -sensibilityController;
        if (right)
        {
            rigidbody2.AddForce(transform.right * speedMovement * Time.deltaTime, ForceMode2D.Force);
        }
        if (left)
        {
            rigidbody2.AddForce(-transform.right * speedMovement * Time.deltaTime, ForceMode2D.Force);
        }
        if (up)
        {
            rigidbody2.AddForce(transform.up * speedMovement * Time.deltaTime, ForceMode2D.Force);
        }
        if (down)
        {
            rigidbody2.AddForce(-transform.up * speedMovement * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
