using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob_Constructor : ConstructorClass
{
    // Start is called before the first frame update
    [Header("Datos de la clase Bob que se suman a tus skills al pasar de nivel")]
    protected int indexDataLevelUpBob;
    [System.Serializable]
    public class DataLevelUpBob
    {
        //Aqui van las estadisticas que se subiran del nivel de bob
        //Estas estadisticas no se asignas sino que se suman a las que ya tenes
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
