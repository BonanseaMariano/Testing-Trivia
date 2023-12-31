using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;

    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;
    public int puntos = 0;

    private void Start()
    {
        ScoreManager.GetInstance().Puntos = 0;
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();
        NextQuestion();
    }

    private void NextQuestion()
    {
        m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine( GiveAnswerRoutine(optionButton) );
    }

    //Corrutina (Investigar)
    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();
        
        //? es el operador ternario, mediante una variable bool si esta es correcta asigna una cosa y caso contrario otra
        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);
        m_audioSource.Play();
        //Por aca seria donde hay que preguntar si selecciono la respuesta correcta o no para lo del puntaje
        if (optionButton.Option.correct)
        {
            puntos++;
            ScoreManager.GetInstance().Puntos++;
        }
            

        yield return new WaitForSeconds(m_waitTime);
        NextQuestion();
    }
}
