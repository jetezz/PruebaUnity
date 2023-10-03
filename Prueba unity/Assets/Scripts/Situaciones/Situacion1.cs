using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// script para la situacion 1
/// </summary>
public class Situacion1 : SituacionTemplate
{
    /*
    *     VARIABLES
    * */

    //PUBLICAS
    public GameObject canvasDniCorrecto;
    public GameObject canvasDniInCorrecto;
    public TextMeshProUGUI textoDniIncorrecto;
    public TextMeshProUGUI textoDniCorrecto;

    //PRIVADAS
    private string dni = "";
    const string textoIncorrecto = "El DNI: {DNI} es incorrecto";
    const string textoCorrecto = "Bienvenido usuario con el DNI: {DNI}";


    new void Start()
    {
        //llamamos al start del padre para coger los valores iniciales para todos las situaciones
        base.Start();
        if (keyInputs)
        {
            keyInputs.desactivarTeclas();
        }
    }


    /*
    *      FUNCIONES ABSTRACTAS
    * */
    public override void iniciarSituacion()
    {       
        if (keyInputs)
        {         
            keyInputs.desactivarTeclas();
        }
    }
    public override void cortarSituacion()
    {
        keyInputs.activarTeclas();
        situacionManager.logTerminarSituacion();
        return;
    }


    /*
    *      FUNCIONES PUBLICAS
    * */   
    public void setDni(string dni)
    {       
        this.dni = dni;
    }    

    public void buttonAceptar()    {
        
        //comprobamos si el DNI es valido
        //Miramos el length del string
        if (dni.Length != 9)
        {
            dniInvalido();
            return;
        }

        //Separamos numeros y letras
        string dniNumeros = dni.Substring(0, dni.Length - 1);
        string dniLetra = dni.Substring(dni.Length - 1, 1);

        //Comprobamos si la letra introducida es valida (solo permitimos mayusculas)
        if(dniLetra[0] < 'A' || dniLetra[0] > 'Z')
        {
            dniInvalido();
            return;
        }

        //comrobamos si algun numero es un caracter
        foreach (char caracter in dniNumeros)
        {
            if (!char.IsDigit(caracter))
            {
                dniInvalido();
                return;
            }
        }

        //si llega aqui el DNI es correcto
        dniValido();       
    }  

    public void cerrarVentanaDniInvalido()
    {
        canvasDniInCorrecto.SetActive(false);
    }

    public void cerrarVentanaDniValido()
    {
        canvasDniCorrecto.SetActive(false);
        cortarSituacion();
        situacionManager.siguienteSituacion();
    }


    /*
    *      FUNCIONES PRIVADAS
    * */
    private void dniInvalido()
    {        
        textoDniIncorrecto.text = textoIncorrecto.Replace("{DNI}", this.dni);
        canvasDniInCorrecto.SetActive(true);
    }

    private void dniValido()    {

        textoDniCorrecto.text = textoCorrecto.Replace("{DNI}", this.dni);
        canvasDniCorrecto.SetActive(true);
    }

   
}
