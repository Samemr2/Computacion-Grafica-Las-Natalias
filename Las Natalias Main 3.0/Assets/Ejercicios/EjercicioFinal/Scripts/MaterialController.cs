using UnityEngine;
using UnityEngine.UI;

public class MaterialController : MonoBehaviour
{
    [SerializeField] private Slider intensitySlider;
    [SerializeField] private Material materialEffect;
    private float intensityValue = 1.0f;

    void Update()
    {
        // Utiliza el valor del slider para ajustar la intensidad (_Power) del material
        intensityValue = Mathf.Clamp(intensitySlider.value, -1.0f, 2.0f);
        materialEffect.SetFloat("_Power", intensityValue);
    }
}

