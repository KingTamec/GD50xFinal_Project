using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = 0;

        if (fill != null)
        {
            fill.color = gradient.Evaluate(0f);
        }
    }

    public void SetValue(float value)
    {
        slider.value = value;

        if (fill != null)
        {
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
