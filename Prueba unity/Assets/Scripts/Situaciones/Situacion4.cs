using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script para la situacion 4
/// </summary>
public class Situacion4 : SituacionTemplate
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS

    //PRIVADAS
    private GameObject cubo;     

    private float tiempo = 0;
    private int contador = 0;

    private const float gravedad = -9;
    private const float velocidadInicial = 10;
    private const float posicionInicial = 0;


    void Update()
    {
        //llamamos a las fisicas para generar la nueva posicion del cubo
        fisicas(cubo);

        //si el cubo vuelve al estado inicial pasamos a la siguiente fase
        if (cubo.transform.position.y < 0)
        {
            contador++;
            fases();
        }
    }

    /*
    *      FUNCIONES ABSTRACTAS
    * */
    public override void iniciarSituacion()
    {      
        //crear cubo
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);

        //inicializar valores de las fisicas
        tiempo = 0;
        contador = 0;

        //activar el update
        enabled = true;       
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
    private void fisicas(GameObject cubo)
    {
        // x = x0 + v0*t + 1/2*a*t^2       
       
        //actualizamos el tiempo
        tiempo += Time.deltaTime;  
        
        //cogemos la posicion en la que deberia estar el cubo en el eje y
        float posicion = posicionInicial + (velocidadInicial * tiempo) + (gravedad/2) * (tiempo * tiempo);

        //colocamos el cubo en la posicion correspondiente
        cubo.transform.position = new Vector3(0, posicion, 0);
       
    }

    private void fases()
    {
        //dependiendo del contador de fases decidimos el comportamiento que va a realizar el cubo
        switch (contador)
        {
            //si entramos en fase 1 el cubo tiene que empezar otra vez la animacion por lo que reseteamos el tiempo y cambiamos el color
            case 1:              
                cubo.GetComponent<Renderer>().material.color = Color.blue;
                tiempo = 0;
                break;

            //en la fase 2 el cubo ya ha hecho 2 veces la animacion por lo que terminamos la situacion
            case 2:
                finalizarSituacion();
                break;           
        }
    }

    private void finalizarSituacion()
    {
        cortarSituacion();
        situacionManager.siguienteSituacion();
    }
}


