using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TeamCharacter
    {
        Team1,
        Team2,
    }
    public enum StateCharacter
    {
        /*
        Quemado (Produce daño por segundo)
        Desangrado (Produce daño por segundo, pero un daño mayor al “Quemado”)
        Inmolación (Produce el estado “Quemado” a todo lo que le pegas o te pega)
        Sobrecarga (mayor velocidad de ataque)
        Electrificado (los golpes electrificados  hacen más daño y poseen un mini-stun que dura 0,5 segundos por golpe)
        Lentitud (Ralentiza al jugador)
        Veneno (Realiza daño por segundo)
        Electrocutado (Te paraliza y hace un daño único por el impacto)
        */
        None,
        Congelado,
        Quemado,
        Desangrado,
        Inmolacion,
        Sobrecarga,
        Electrificado,
        Lentitud,
        Veneno,
        Electrocutado,
    }
    public TeamCharacter team;
    public StateCharacter state;
    protected bool enableMovement;
    public float delayStateCongelado;
    [Header("Datos Generales de cualquier Character")]
    public int currentLife;
    public int maxLife;
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckState();
    }
    public void CheckState()
    {
        switch (state)
        {
            case StateCharacter.None:
                enableMovement = true;

                break;
            case StateCharacter.Congelado:
                if (delayStateCongelado > 0)
                {
                    delayStateCongelado = delayStateCongelado - Time.deltaTime;
                    enableMovement = false;
                }
                else
                {
                    state = StateCharacter.None;
                }
                break;
            case StateCharacter.Desangrado:
                break;
            case StateCharacter.Electrificado:
                break;
            case StateCharacter.Electrocutado:
                break;
            case StateCharacter.Inmolacion:
                break;
            case StateCharacter.Lentitud:
                break;
            case StateCharacter.Quemado:
                break;
            case StateCharacter.Sobrecarga:
                break;
            case StateCharacter.Veneno:
                break;
        }
    }
}
