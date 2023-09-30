using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script para la gestion del los estados (situacion) de la aplicacion
/// </summary>
public class SituacionManager : MonoBehaviour
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS
    public GameObject[] todasSituaciones;
    public int situacionActual = 0;

    //PRIVADAS   
    private int numSituaciones ;
    private SituacionTemplate situacionTemplate;
    static protected Logger logger;
    static protected KeyInputs keyInputs;  
   

    void Start()
    {       
        if (todasSituaciones.Length > 0)
        {
            //inicializamos los componentes externos que necesitamos
            keyInputs = GetComponent<KeyInputs>();
            logger = GetComponent<Logger>();
            numSituaciones = todasSituaciones.Length - 1;

            //lanzamos su funcion abstracta de inicializar
            iniciarSituacion(situacionActual);   
        }
    }

    private void Update()
    {
        //lanzamos la funcionalidad de comprobar teclas del otro scrip y guardamos si se ha pulsado alguna tecla o no
        Enums.Situaciones situacion = keyInputs.comprobarTeclas();
        if (situacion != Enums.Situaciones.SinSituacion)
        {
            //si se ha pulsado tecla pasamos el enum a int y asi podemos lanzar la siguacion correspondiente a la tecla pulsada
            logger.WriteToLog(((Enums.Situaciones)situacion).ToString(), "FORZAR");
            terminarSituacion();
            situacionActual = (int)situacion;
            iniciarSituacion((int)situacion);
        }
    }

    /*
    *      FUNCIONES PUBLICAS
    * */

    public void siguienteSituacion()
    {
        todasSituaciones[situacionActual].SetActive(false);

        //comprobamos si es la ultima situacion
        situacionActual++;
        if (situacionActual > numSituaciones)
        {
            situacionActual = 0;
        }

        iniciarSituacion(situacionActual);

    }
    public void iniciarSituacion(int situacion)
    {
        //lanzamos su funcion abstracta de inicializar
        situacionTemplate = todasSituaciones[situacion].GetComponent<SituacionTemplate>();

        if (situacionTemplate)
        {
            //hacemos log de entrar en una situacion           
            logger.WriteToLog(((Enums.Situaciones)situacion).ToString(), "ENTRA");
            situacionTemplate.iniciarSituacion();
            todasSituaciones[situacion].SetActive(true);

        }
    }
    public void logTerminarSituacion()
    {
        logger.WriteToLog(((Enums.Situaciones)situacionActual).ToString(), "SALE");
    }


    /*
    *     FUNCIONES PRIVADAS
    * */
    private void terminarSituacion()
    {
        //lanzamos su funcion abstracta de finalizar
        todasSituaciones[situacionActual].SetActive(false);
        situacionTemplate = todasSituaciones[situacionActual].GetComponent<SituacionTemplate>();
        if (situacionTemplate)
        {
            situacionTemplate.cortarSituacion();
        }       
    }   
}
