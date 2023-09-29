using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituacionManager : MonoBehaviour
{
    public GameObject[] todasSituaciones;

    private int situacionActual = 2;
    private int numSituaciones ;
    private SituacionTemplate situacionTemplate;

    void Start()
    {
        

        if (todasSituaciones.Length > 0)
        {
            numSituaciones = todasSituaciones.Length - 1;

            //activamos el gameObject correspondiente
            todasSituaciones[situacionActual].SetActive(true);

            //lanzamos su funcion abstracta de inicializar
            situacionTemplate = todasSituaciones[situacionActual].GetComponent<SituacionTemplate>();
            if (situacionTemplate)
            {
                situacionTemplate.iniciarSituacion();
            }
           
        }
    }
    public void siguienteSituacion()
    {
       
        todasSituaciones[situacionActual].SetActive(false);

        //comprobamos si es la ultima situacion
        situacionActual++;       
        if (situacionActual > numSituaciones)
        {
            situacionActual = 0;
        }

        //lanzamos su funcion abstracta de inicializar
        situacionTemplate = todasSituaciones[situacionActual].GetComponent<SituacionTemplate>();
        Debug.Log(situacionTemplate);
        if (situacionTemplate)
        {
            situacionTemplate.iniciarSituacion();
            todasSituaciones[situacionActual].SetActive(true);
            Debug.Log(situacionActual);
        }        
             
    }
}
