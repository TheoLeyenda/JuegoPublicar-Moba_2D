﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinionBehaviour : MonoBehaviour
{
    public enum StatePath
    {
        Nulo,
        EnUso
    }
    private StatePath statePath;
    public float speed;
    public float capacity;
    private float cantOro;
    private float cantPiedra;
    private float cantAlimento;
    private float cantMadera;
    private FSM fsmMinero;
    private List<GameObject> Depositos;
    //Esta variable contendra la posicion donde se encuentra el trabajo a realizar(la posicion de la casa a construir o la mina la cual minar, etc).
    private GameObject objetivoTrabajo;
    private Transform posicionActual;
    private GameObject depositoMasCercano;
    private bool generarNodoActual = true;
    private bool nodoFinalObstaculo;
    private bool nodoInicialObstaculo;
    private int i = 0;
    //private PathGenerator path;
    [HideInInspector]
    public string trabajo;
    //HAGO UN ENUM DE Estados
    public enum EstadosMinero
    {
        Idle,
        IrAMinar,
        Minando,
        LLevarOro,
        DepositarOro,
        CancelarAccion,
        Count
    }
    //HAGO UN ENUM DE Eventos
    public enum EventosMinero
    {
        ClickInMine,
        CollisionMine,
        FullCapasity,
        CollisionHouse,
        Stop,
        Count
    }
    private void Awake()
    {
        nodoFinalObstaculo = false;
        nodoInicialObstaculo = false;
        statePath = StatePath.Nulo;
        Depositos = new List<GameObject>();
        
        // Aca defino las relaciones de estado y le hago el new al objeto FSM
        fsmMinero = new FSM((int)EstadosMinero.Count, (int)EventosMinero.Count, (int)EstadosMinero.Idle);

        fsmMinero.SetRelations((int)EstadosMinero.Idle, (int)EstadosMinero.IrAMinar, (int)EventosMinero.ClickInMine);
        fsmMinero.SetRelations((int)EstadosMinero.IrAMinar, (int)EstadosMinero.Minando, (int)EventosMinero.CollisionMine);
        fsmMinero.SetRelations((int)EstadosMinero.IrAMinar, (int)EstadosMinero.CancelarAccion, (int)EventosMinero.Stop);
        fsmMinero.SetRelations((int)EstadosMinero.Minando, (int)EstadosMinero.LLevarOro, (int)EventosMinero.FullCapasity);
        fsmMinero.SetRelations((int)EstadosMinero.Minando, (int)EstadosMinero.CancelarAccion, (int)EventosMinero.Stop);
        fsmMinero.SetRelations((int)EstadosMinero.LLevarOro, (int)EstadosMinero.DepositarOro, (int)EventosMinero.CollisionHouse);
        fsmMinero.SetRelations((int)EstadosMinero.LLevarOro, (int)EstadosMinero.CancelarAccion, (int)EventosMinero.Stop);
        fsmMinero.SetRelations((int)EstadosMinero.DepositarOro, (int)EstadosMinero.Idle, (int)EventosMinero.Stop);
        fsmMinero.SetRelations((int)EstadosMinero.DepositarOro, (int)EstadosMinero.IrAMinar, (int)EventosMinero.ClickInMine);
        fsmMinero.SetRelations((int)EstadosMinero.CancelarAccion, (int)EstadosMinero.Idle, (int)EventosMinero.Stop);
    }

    private void Start()
    {
       
        nodoFinalObstaculo = false;
        nodoInicialObstaculo = false;
        statePath = StatePath.Nulo;
    }
    // Update is called once per frame
    void Update()
    {
        //HAGO EL SWITCH DE LA MAQUINA DE ESTADOS
        switch (fsmMinero.GetCurrentState())
        {
            case (int)EstadosMinero.Idle:
                IdleMinero();
                break;
            case (int)EstadosMinero.IrAMinar:
                IrAMinar();
                break;
            case (int)EstadosMinero.Minando:
                Minar();
                break;
            case (int)EstadosMinero.LLevarOro:
                LLevarOro();
                break;
            case (int)EstadosMinero.DepositarOro:
                DepositarOro();
                break;           
        }

    }

    
    public void SetObjetivoTrabajo(GameObject _objetivoTrabajo)
    {
        objetivoTrabajo = _objetivoTrabajo;
    }
    public void SetPosisionActual(Transform _posicionActual)
    {
        posicionActual = _posicionActual;
    }
    //HAGO LAS FUNCIONES QUE VA A LLAMAR EL SWITCH DE LA MAQUINA DE ESTADOS UBICADA EN EL Update()
    public void IdleMinero()
    {
        //Animacion del minero con un cacho de oro en caso de tenerlo
        //sino tiene oro en sima se ejecuta la animacion "Idle" del aldeano en si
        if (trabajo == "Minar")
        {
            fsmMinero.SendEvent((int)EventosMinero.ClickInMine);
            i = 0;
        }
        else
        {
            //CORRER ANIMACION IDLE
        }
    }
    public void IrAMinar()
    {
        Debug.Log("Yendo a Minar");
        if (objetivoTrabajo.gameObject.activeSelf)
        {
                         
        }
        else
        {
            fsmMinero.SendEvent((int)EstadosMinero.Idle);
        }
    }
    public void Minar()
    {
        Debug.Log("Minando");
        i = 0;
        //SE EJECUTA LA ANIMACION DE MINAR
        statePath = StatePath.Nulo;
        if (objetivoTrabajo.gameObject.activeSelf)
        {
            cantOro = cantOro + Time.deltaTime;
            Debug.Log("cantOro: " + (int)cantOro);
        }
        if (cantOro >= capacity)
        {
            Debug.Log("FULL CAPASITY");
            fsmMinero.SendEvent((int)EventosMinero.FullCapasity);
        }
        if (!objetivoTrabajo.gameObject.activeSelf)
        {
            fsmMinero.SendEvent((int)EventosMinero.FullCapasity);
        }
        if (nodoFinalObstaculo)
        {
            
        }
        

    }
    public void LLevarOro()
    {
        Debug.Log("Llevando el oro");
        //DEBERIA FIJARSE CUAL ES EL ALMACEN DE ORO O CENTRO URBANO MAS CERCANO
        BuscarAlmacenMasCercano();
    }
    public void DepositarOro()
    {
        Debug.Log("Depositando oro");
        i = 0;
        //Debug.Log("DEPOSITANDO ORO");
        statePath = StatePath.Nulo;
        
        cantOro = 0;
        fsmMinero.SendEvent((int)EventosMinero.ClickInMine);     

    }
    public void BuscarAlmacenMasCercano()
    {

        for (int i = 0; i < SceneManager.GetActiveScene().GetRootGameObjects().Length; i++)
        {
            if (SceneManager.GetActiveScene().GetRootGameObjects()[i].tag == "Centro Urbano" || SceneManager.GetActiveScene().GetRootGameObjects()[i].tag == "Deposito Minero")
            {
                depositoMasCercano = SceneManager.GetActiveScene().GetRootGameObjects()[i].gameObject;
                Depositos.Add(SceneManager.GetActiveScene().GetRootGameObjects()[i]);

            }
        }
        for (int i = 0; i < Depositos.Count; i++)
        {
            if (Depositos[i].transform.position.magnitude < depositoMasCercano.transform.position.magnitude)
            {
                depositoMasCercano = Depositos[i].gameObject;
            }

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (trabajo == "Minar" && other.gameObject.tag == "Centro Urbano" && cantOro > 0)
        {
            //Debug.Log("DEPOSITANDO ORO");
            fsmMinero.SendEvent((int)EventosMinero.CollisionHouse);
        }
    }
   
}

