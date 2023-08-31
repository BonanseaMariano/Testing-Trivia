using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public Text timerText;
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "" + timer.ToString("f0");
    }
}
