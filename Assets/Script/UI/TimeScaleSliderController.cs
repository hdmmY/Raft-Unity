﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeScaleSliderController : MonoBehaviour
{
    public Slider m_timeScaleSlider;

    public TMPro.TextMeshProUGUI m_timeScaleText;

    private void Update()
    {
        int scale = (int)(m_timeScaleSlider.maxValue + m_timeScaleSlider.minValue - m_timeScaleSlider.value);
        scale = (int)(Mathf.Pow(scale / 1000f, 4) * 1000);

        RaftTime.Instance.TimeScale = 1f / scale;
        m_timeScaleText.text = scale.ToString();
    }                                                      
}
