using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situacion2 : SituacionTemplate
{
    private GameObject cubo;

    private float tiempoTrascurrido = 0;

    public override void iniciarSituacion()
    {
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);

        enabled = true;
        tiempoTrascurrido = 0;        

    }

    void Update()
    {        
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

    private void finalizarSituacion()
    {
        enabled = false;
        Destroy(cubo);
        
        situacionManager.siguienteSituacion();
    }
}

   
