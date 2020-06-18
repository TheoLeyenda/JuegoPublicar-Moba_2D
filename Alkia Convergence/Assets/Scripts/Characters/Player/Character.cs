using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Datos Generales que se suman a tus skills al pasar de nivel")]
    protected int indexDataLevelUpCharacter;
    [System.Serializable]
    public class DataLevelUpCharacter
    {
        //Aqui van las estadisticas que se subiran del nivel de cada personaje
        //Estas estadisticas no se asignas sino que se suman a las que ya tenes
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
