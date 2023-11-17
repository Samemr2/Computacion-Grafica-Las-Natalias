using UnityEngine;


public class PressKey : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private GameObject currentInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            InstanciarPrefab();
        }
    }

    void InstanciarPrefab()
    {
        // Destruye la instancia actual si existe
        if (currentInstance != null)
        {
            Destroy(currentInstance);
        }

        // Verifica que el prefab esté asignado
        if (prefabToInstantiate != null)
        {
            // Instancia el nuevo prefab
            currentInstance = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            // Puedes hacer más configuraciones aquí si es necesario
        }
        else
        {
            Debug.LogError("No se ha asignado el prefab en el Inspector.");
        }
    }
}
