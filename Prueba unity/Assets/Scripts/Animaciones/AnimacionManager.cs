using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// script para gestionar las animaciones
/// </summary>

public class AnimacionManager : MonoBehaviour
{
    /*
    *     VARIABLES
    * */

    //PUBLICAS
    public Animator animatorIzquierda;
    public Animator animatorDerecha;
    public GameObject cartelFinalizado;
    public GameObject cartelCortado;

    //PRIVADAS    
    private SituacionManager situacionManager;
    static protected KeyInputs keyInputs;

    private void Start()
    {
        situacionManager = FindObjectOfType<SituacionManager>();
        keyInputs = FindObjectOfType<KeyInputs>();
    }
    /*
    *      FUNCIONES PUBLICAS
    * */

    public void animacionCortarSituacion(int situacion)
    {
        cartelCortado.SetActive(true);
        animacionPuerta(situacion,cartelCortado);
    }

    public void animacionSituacionFinalizada(int situacion)
    {
        cartelFinalizado.SetActive(true);
        animacionPuerta(situacion,cartelFinalizado);
    }
   


    /*
     *      FUNCIONES PRIVADAS
     * */

    private void animacionPuerta(int situacion,GameObject cartel)
    {
        if (keyInputs)
        {
            keyInputs.desactivarTeclas();
        }       
        cerrarPuerta();
        StartCoroutine(abrirPuerta(situacion, cartel));
    }
    private IEnumerator abrirPuerta(int situacion, GameObject cartel)
    {
        yield return new WaitForSeconds(1);       
        animatorIzquierda.SetBool("Cerrar", false);
        animatorDerecha.SetBool("Cerrar", false);
        cartel.SetActive(false);        
        if (keyInputs)
        {
            keyInputs.activarTeclas();
        }
        situacionManager.iniciarSituacion(situacion);
    }

    private void cerrarPuerta()    
    {               
        animatorIzquierda.SetBool("Cerrar", true);
        animatorDerecha.SetBool("Cerrar", true);       
    }

   

}
