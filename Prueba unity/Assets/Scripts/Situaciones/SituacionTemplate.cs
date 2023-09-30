using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script padre para todas las situaciones
/// </summary>
public abstract class SituacionTemplate : MonoBehaviour
{
    /*
    *     VARIABLES
    * */

    //PUBLICAS
    //PRIVADAS
    static protected SituacionManager situacionManager;
    static protected Logger logger;


    protected void Start()
    {      
        situacionManager = FindObjectOfType<SituacionManager>();
        logger = GetComponent<Logger>();
    }

    /*
    *      FUNCIONES ABSTRACTAS
    * */
    public abstract void iniciarSituacion();
    public abstract void cortarSituacion();

    /*
    *      FUNCIONES PUBLICAS
    * */

    /*
     *      FUNCIONES PRIVADAS
     * */


}
