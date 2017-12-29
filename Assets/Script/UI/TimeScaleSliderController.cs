using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeScaleSliderController : MonoBehaviour
{
    public Slider m_timeScaleSlider;

    public Text m_timeScaleText;

    public void Update()
    {
        int scale = (int)(m_timeScaleSlider.maxValue + m_timeScaleSlider.minValue - m_timeScaleSlider.value);
        RaftTime.Instance.TimeScale = 1f / scale;
        m_timeScaleText.text = scale.ToString();
    }                                                      
}
