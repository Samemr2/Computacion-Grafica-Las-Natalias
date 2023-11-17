using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private Slider fresnelSlider;
    [SerializeField] private Material materialEffect;
    private float fresnelValue;

    void Update()
    {
        // Utiliza el valor del slider para ajustar la intensidad (_Power) del material
        fresnelValue = Mathf.Clamp(fresnelSlider.value, 0f, 10.0f);
        materialEffect.SetFloat("_FresnelPower", fresnelValue);
    }
}
