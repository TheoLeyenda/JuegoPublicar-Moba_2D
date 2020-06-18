using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorClass : CharacterPlayer
{
    [Header("Datos de la clase Constructor que se suman a tus skills al pasar de nivel")]
    protected float speedConstruction;
    [System.Serializable]
    public class DataLevelUpConstructor
    {
        //Aqui van las estadisticas que se subiran del nivel de bob
        //Estas estadisticas no se asignas sino que se suman a las que ya tenes
        public float addSpeedConstruction;
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
