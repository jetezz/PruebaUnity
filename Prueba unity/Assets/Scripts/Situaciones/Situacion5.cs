using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Situacion5 : SituacionTemplate
{


    public override void iniciarSituacion()
    {       

    }

    public void botonCerrar()
    {
        situacionManager.siguienteSituacion();
    }


   

   
}
