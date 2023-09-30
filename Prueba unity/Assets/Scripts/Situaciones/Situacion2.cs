using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script para la situacion 2
/// </summary>
public class Situacion2 : SituacionTemplate
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS

    //PRIVADAS
    private GameObject cubo;
    private float tiempoTrascurrido = 0;

    void Update()
    {
        //calculamos el tiempo transcurrido
        tiempoTrascurrido += Time.deltaTime;

        if (tiempoTrascurrido > 0.1 && tiempoTrascurrido < 2)
        {
            cubo.GetComponent<Renderer>().material.color = Color.green;
        }

        if (tiempoTrascurrido > 2)
        {
            cubo.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (tiempoTrascurrido > 5)
        {
            finalizarSituacion();
        }

    }

    /*
    *      FUNCIONES ABSTRACTAS
    * */
    public override void iniciarSituacion()
    {
        //generamos un cubo
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);

        enabled = true;
        tiempoTrascurrido = 0;        

    }

    public override void cortarSituacion()
    {
        enabled = false;
        Destroy(cubo);
        situacionManager.logTerminarSituacion();
        return;
    }

    /*
    *      FUNCIONES PUBLICAS
    * */


    /*
    *      FUNCIONES PRIVADAS
    * */
    private void finalizarSituacion()
    {
        cortarSituacion();        
        situacionManager.siguienteSituacion();
    }
}

   
