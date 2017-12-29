using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTermTextController : MonoBehaviour
{
    public RaftServerProperty m_serverProperty;

    public TMPro.TextMeshProUGUI m_curTermText;

    private void Update()
    {
        m_curTermText.text = m_serverProperty.m_currentTerm.ToString();
    }
}
