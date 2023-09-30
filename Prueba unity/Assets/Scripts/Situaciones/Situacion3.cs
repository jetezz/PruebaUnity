using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script para la situacion 3
/// </summary>
public class Situacion3 : SituacionTemplate
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS
    public delegate void MiDelegado();

    //PRIVADAS
    private MiDelegado[] fases = new MiDelegado[numFases];

    private GameObject cubo;
    private int fase;
    private const float velocidadRotation = 30;
    private const float maxRotation = 135;
    private const float minRotation = -135;

    private const int girarDerecha = 0;
    private const int girarIzquierda = 1;
    private const int finalizar = 2;
    private const int numFases = 3;

    new void Start()
    {
        //llamamos al start del padre para coger los valores iniciales para todos las situaciones
        base.Start();

        //metemos los delegados en un array para poder llamarlo de forma mas facil
        fases[girarDerecha] = fase1;
        fases[girarIzquierda] = fase2;
        fases[finalizar] = finalizarSituacion;        
    }

    void Update()
    {
        //si el cubo pasa de la rotacion maxima cambiamos de fase a girar a la izquierda
        if (cubo.transform.rotation.eulerAngles.y > maxRotation)
        {
            cubo.GetComponent<Renderer>().material.color = Color.yellow;
            fase = girarIzquierda;
        }

        //si el cubo pasa de la rotacion minima pasamos a la fase finalizar (hay que tener en cuenta si la rotacion es positiva
        //o negativa ya que en unity no usa angulos en negativo)
        if (cubo.transform.rotation.eulerAngles.y < 380 + minRotation && cubo.transform.rotation.y < 0)
        {
            fase = finalizar;
        }

        //lanzamos el delegado con la fase en la que estamos
        fases[fase]();
    }

    /*
    *      FUNCIONES ABSTRACTAS
    * */
    public override void iniciarSituacion()
    {
        //inicializamos la fase al estado girar a la derecha
        fase = girarDerecha;

        //generamos el cubo y le ponemos color inicial
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);
        cubo.GetComponent<Renderer>().material.color = Color.red;

        //activamos el update
        enabled = true;       
    }

    public override void cortarSituacion()
    {
        enabled = false;
        Destroy(cubo);
        situacionManager.logTerminarSituacion();        
    }



    /*
    *      FUNCIONES PUBLICAS
    * */

    /*
    *      FUNCIONES PRIVADAS
    * */
    private void fase1()
    {
        //girar a la derecha
        cubo.transform.Rotate(0, velocidadRotation * Time.deltaTime, 0);
    }
    private void fase2()
    {     
        //girar a la izquierda
        cubo.transform.Rotate(0, -velocidadRotation * Time.deltaTime, 0);
    }

    private void finalizarSituacion()
    {
        cortarSituacion();       
        situacionManager.siguienteSituacion();
    }
}


