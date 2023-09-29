using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Situacion1 : SituacionTemplate
{
    public GameObject canvasDniCorrecto;
    public GameObject canvasDniInCorrecto;

    public TextMeshProUGUI textoDniIncorrecto;
    public TextMeshProUGUI textoDniCorrecto;

    private string dni = "";

    const string textoIncorrecto = "El DNI: {DNI} es incorrecto";
    const string textoCorrecto = "Bienvenido usuario con el DNI: {DNI}";


    public override void iniciarSituacion()
    {
        return;
    }

    public void setDni(string dni)
    {       
        this.dni = dni;
    }

    public void buttonAceptar()    {
        
        //Miramos el length del string
        if (this.dni.Length != 9)
        {
            dniInvalido();
            return;
        }

        //Separamos numeros y letras
        string dniNumeros = dni.Substring(0, dni.Length - 1);
        string dniLetra = dni.Substring(dni.Length - 1, 1);

        //Comprobamos si la letra introducida es valida
        if(dniLetra[0] < 'A' || dniLetra[0] > 'Z')
        {
            dniInvalido();
            return;
        }

        //comrobamos si se ha introducido un numero valido
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
        situacionManager.siguienteSituacion();
    }


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
