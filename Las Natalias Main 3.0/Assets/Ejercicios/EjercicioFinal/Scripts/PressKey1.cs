using UnityEngine;

public class PressKey1 : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private GameObject currentInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentInstance != null)
            {
                // Si la instancia actual existe, destrúyela
                Destroy(currentInstance);
                currentInstance = null; // Establece la instancia actual como nula
            }
            else
            {
                // Si la instancia actual no existe, crea un nuevo prefab
                InstanciarPrefab();
            }
        }
    }

    void InstanciarPrefab()
    {
        // Verifica que el prefab esté asignado
        if (prefabToInstantiate != null)
        {
            // Instancia el nuevo prefab
            currentInstance = Instantiate(prefabToInstantiate);
        }
        else
        {
            Debug.LogError("No se ha asignado el prefab en el Inspector.");
        }
    }
}

