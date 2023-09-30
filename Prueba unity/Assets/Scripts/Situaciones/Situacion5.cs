using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// script para la situacion 5
/// </summary>
public class Situacion5 : SituacionTemplate
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS

    //PRIVADAS

    /*
    *      FUNCIONES ABSTRACTAS
     * */
    public override void iniciarSituacion(){}
    public override void cortarSituacion()
    {
        situacionManager.logTerminarSituacion();
        return;
    }


    /*
    *      FUNCIONES PUBLICAS
    * */
    public void botonCerrar()
    {
        cortarSituacion();
        situacionManager.siguienteSituacion();
    }

    /*
    *     FUNCIONES PRIVADAS
    * */





}
