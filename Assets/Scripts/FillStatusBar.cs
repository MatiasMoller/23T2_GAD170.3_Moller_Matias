using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image fillImage;
    private Slider slider;

    private void Awake()
    {
       // slider = GetComponent<Slider>();
    }

    void Update()
    {
        //if (slider.value <= slider.minValue)
        //{
        //    fillImage.enabled = false;
        //}
        //if (slider.value > slider.minValue && !fillImage.enabled)
        //{
        //    fillImage.enabled = true;
        //}

        //float fillValue = health.currentHealth / (float)health.maxHealth;
        ////slider.value = fillValue; // Update the slider's value
        //if (fillValue <= slider.maxValue / 3)
        //{
        //    fillImage.color = Color.white;
        //}
        //else
        //{
        //    fillImage.color = Color.red;
        //}
    }
}
