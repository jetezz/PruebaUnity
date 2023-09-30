using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// script para la gestion del los logs de la aplicacion
/// </summary>
public class Logger : MonoBehaviour
{ 
    /*
    *     VARIABLES
    * */
    //PUBLICAS
    public string logFileName = "log.txt";
    public string logPath = "Logger/";
    public const string title = "Inicio de prueba";

    //PRIVADAS
    private string logFilePath;     

    void Start()
    {
        logFilePath = Path.Combine(Application.dataPath, logPath, logFileName);       

        //Reseteamos el fichero 
        File.WriteAllText(logFilePath, "");

        //Escribimos el primer log
        WriteToLog(title);
       


    }

    /*
    *      FUNCIONES PUBLICAS
    * */

    public void WriteToLog(string message, string situacion = "Sin situacion")
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            //escribimos en el fichero una nueva linea con el formato MARCADETIEMPO;SITUACION;ESTADO
            writer.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ";" + situacion + ";" + message);
        }
    }
}
