using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExplosionController : MonoBehaviour
{
    [SerializeField] private Slider powerSlider;
    [SerializeField] private Material materialEffect;
    private float powerValue;

    void Update()
    {
        // Utiliza el valor del slider para ajustar la intensidad (_Power) del material
        powerValue = Mathf.Clamp(powerSlider.value, 0f, 10.0f);
        materialEffect.SetFloat("_VertexOffset", powerValue);
    }
}
