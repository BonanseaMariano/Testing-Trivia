using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGameOver : MonoBehaviour
{
    //En gameManager es donde esta mi variable de puntos
    private GameManager puntaje = null;
    
    private GameObject m_textMeshPro = null;
    private void Awake()
    {
        //Aca es donde instancio 
        puntaje = FindObjectOfType<GameManager>();

        m_textMeshPro = GameObject.Find("TextoPuntaje");
        TextMeshProUGUI textoact = m_textMeshPro.GetComponent<TextMeshProUGUI>();

        textoact.text = "Juego terminado\nganaste!";
        
        //Corregir
        //textoact.text = "Juego terminado\nobtuviste "+puntaje.puntos+" puntos";
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
