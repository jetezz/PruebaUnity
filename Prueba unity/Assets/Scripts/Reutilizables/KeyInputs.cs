using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script para la gestion del pusado de teclas
/// </summary>
public class KeyInputs : MonoBehaviour
{
    /*
    *     VARIABLES
    * */
    //PUBLICAS

    //PRIVADAS
    private bool isKeyPressed = false;
    private static bool teclasActivadas = true;
    private float contador = 0; 


    /*
    *      FUNCIONES PUBLICAS
    * */
    public Enums.Situaciones comprobarTeclas()    {
        contador += Time.deltaTime;


        if (!isKeyPressed && teclasActivadas && contador > 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))            {
                contador = 0;
                isKeyPressed = true;
                return Enums.Situaciones.Situacion1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                contador = 0;
                isKeyPressed = true;
                return Enums.Situaciones.Situacion2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                contador = 0;
                isKeyPressed = true;
                return Enums.Situaciones.Situacion3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                contador = 0;
                isKeyPressed = true;
                return Enums.Situaciones.Situacion4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                contador = 0;
                isKeyPressed = true;
                return Enums.Situaciones.Situacion5;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {          
            isKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            isKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            isKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            isKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            isKeyPressed = false;
        }       

        return Enums.Situaciones.SinSituacion;


    }

    public void desactivarTeclas()
    {
        teclasActivadas = false;
    }

    public void activarTeclas()
    {
        teclasActivadas = true;
    }
  
}
