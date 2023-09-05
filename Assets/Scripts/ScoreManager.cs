using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public static ScoreManager Instancia;
    public int Puntos = 0;


    public static ScoreManager GetInstance() 
    {
        if (Instancia == null) Instancia = new ScoreManager();
        return Instancia;
    }

}
