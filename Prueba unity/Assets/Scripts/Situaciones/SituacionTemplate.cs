using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SituacionTemplate : MonoBehaviour
{
    static protected SituacionManager situacionManager;
    protected void Start()
    {      
        situacionManager = FindObjectOfType<SituacionManager>();
    }      

    public abstract void iniciarSituacion();


}
