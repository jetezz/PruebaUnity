using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situacion4 : SituacionTemplate
{
    
    private GameObject cubo;     

    private float tiempo = 0;
    private int contador = 0;

    const float gravedad = -9;
    const float velocidadInicial = 10;
    const float posicionInicial = 0;   

    public override void iniciarSituacion()
    {      
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);
        tiempo = 0;
        contador = 0;
        enabled = true;       
    }

    void Update()
    {
        fisicas(cubo);
        if(cubo.transform.position.y < 0)
        {
            contador++;
            fases();
        }        

    }  

    private void fisicas(GameObject cubo)
    {
        // x = x0 + v0*t + 1/2*a*t^2
        // v = v0 + a*t
       
        tiempo += Time.deltaTime;
        

        //float velocidad = velocidadInicial + (gravedad * tiempo);
        
        float posicion = posicionInicial + (velocidadInicial * tiempo) + (gravedad/2) * (tiempo * tiempo);

        cubo.transform.position = new Vector3(0, posicion, 0);
       
    }

    private void fases()
    {
        switch (contador)
        {
            case 1:
                cubo.GetComponent<Renderer>().material.color = Color.blue;
                tiempo = 0;
                break;

            case 2:
                finalizarSituacion();
                break;           
        }
    }

    private void finalizarSituacion()
    {
        enabled = false;
        Destroy(cubo);
        situacionManager.siguienteSituacion();
    }
}


