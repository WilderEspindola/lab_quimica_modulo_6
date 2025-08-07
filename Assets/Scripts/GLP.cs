using UnityEngine;

public class GLP : MonoBehaviour
{
    public GameObject infoButton; // Arrastra el Bot�n 2 (informaci�n) aqu� en el Inspector

    private bool isInfoVisible = false;

    public void ToggleInfo()
    {
        isInfoVisible = !isInfoVisible; // Alternar estado
        infoButton.SetActive(isInfoVisible); // Mostrar/ocultar
    }
}
