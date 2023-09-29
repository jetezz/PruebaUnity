using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situacion3 : SituacionTemplate
{
    public delegate void MiDelegado();
    public MiDelegado[] fases = new MiDelegado[numFases];

    private GameObject cubo;
    private int fase = 0;
    const float velocidadRotation = 30;
    const float maxRotation = 135;
    const float minRotation = -135;

    const int girarDerecha = 0;
    const int girarIzquierda = 1;
    const int finalizar = 2;
    const int numFases = 3;

    new void Start()
    {
        base.Start();
        fases[girarDerecha] = fase1;
        fases[girarIzquierda] = fase2;
        fases[finalizar] = finalizarSituacion;
    }
    public override void iniciarSituacion()
    {
        fase = girarDerecha;
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, 0, 0);
        cubo.GetComponent<Renderer>().material.color = Color.red;
        enabled = true;
       
    }

    void Update()
    {       
        if (cubo.transform.rotation.eulerAngles.y > maxRotation )
        {
            fase = girarIzquierda;
        }

        if (cubo.transform.rotation.eulerAngles.y < 380 + minRotation && cubo.transform.rotation.y < 0)
        {
            fase = finalizar;
        }

        fases[fase](); 
    }

    public void fase1()
    {
        cubo.transform.Rotate(0, velocidadRotation * Time.deltaTime, 0);
    }
    private void fase2()
    {
        cubo.GetComponent<Renderer>().material.color = Color.yellow;
        cubo.transform.Rotate(0, -velocidadRotation * Time.deltaTime, 0);
    }

    private void finalizarSituacion()
    {
        enabled = false;
        Destroy(cubo);
       
        situacionManager.siguienteSituacion();
    }
}


