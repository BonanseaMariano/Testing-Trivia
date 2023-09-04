using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = null; 

    private List<Question> m_backup = null;
    private GameManager m_gameManager = null;

    private void Awake()
    {
        m_backup = m_questionList.ToList();
        m_gameManager = FindObjectOfType<GameManager>();
    }

    public Question GetRandom(bool remove = true)
    {
        //Ya se agotaron las pregintas, aca es un posible lugar para la funcion GameOver
        if(m_questionList.Count == 0)
        {
            GameOver();
            RestoreBackup();
        }
            
        

        int index = Random.Range(0, m_questionList.Count);

        if(!remove)
            return m_questionList[index];

        Question q = m_questionList[index];
        m_questionList.RemoveAt(index);
        return q;
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup.ToList();
    }

    //Para configurar el final del juego (hay que ver cuando se lo quiere llamar en QuizDB es un posible lugar)
    private void GameOver()
    {
        print("Juego terminado, obtuviste "+m_gameManager.puntos+" puntos");
        //En vez de recargar la escena hay que hacer la pantalla final del juego
        SceneManager.LoadScene(1);
    }
}

/*  
    La diferencia entre FindObjectOfType<GameManager>() y GetComponent<GameManager>() es que 
    FindObjectOfType<GameManager>() busca en toda la escena un objeto que tenga el componente GameManager 
    y devuelve una referencia a ese objeto, mientras que GetComponent<GameManager>() busca el 
    componente GameManager en el objeto actual.

    Por lo tanto, si tienes varios objetos con el componente GameManager en tu escena y deseas obtener una referencia 
    a uno de ellos, debes usar FindObjectOfType<GameManager>(). Si solo tienes un objeto con el componente GameManager 
    y deseas obtener una referencia a ese componente en ese objeto, debes usar GetComponent<GameManager>().
*/