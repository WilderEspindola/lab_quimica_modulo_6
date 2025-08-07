using UnityEngine;

public class CubeRiser : MonoBehaviour
{
    [Tooltip("Cantidad que sube el cubo en Y (por clic).")]
    public float riseAmount = 0.1f; // Ajustable en el Inspector

    [Tooltip("Altura m�xima permitida (Y no puede ser mayor a esto).")]
    public float maxYPosition = 0.6f; // L�mite superior en Y

    private Vector3 originalPosition; // Guarda la posici�n inicial

    void Start()
    {
        originalPosition = transform.position; // Posici�n exacta inicial
    }

    // M�todo para subir el cubo (llamado por el bot�n UI)
    public void MoveCubeUp()
    {
        Vector3 currentPosition = transform.position;

        // Calcula la nueva posici�n Y (sumando riseAmount, pero no m�s de maxYPosition)
        float newY = Mathf.Min(currentPosition.y + riseAmount, maxYPosition);

        // Aplica el movimiento SOLO en Y (mantiene X y Z originales)
        transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
    }

    // (Opcional) Resetear a la posici�n inicial
    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}