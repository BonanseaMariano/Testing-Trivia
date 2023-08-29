using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;

    public void Construct(Question q, Action<OptionButton> callback)
    {
        m_question.text = q.text;

        for (int i = 0; i < m_buttonList.Count; i++)
        {
            m_buttonList[i].Constructor(q.options[i], callback);
        }
    }
}
