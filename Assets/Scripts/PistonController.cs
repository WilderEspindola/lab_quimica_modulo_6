using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistonController : MonoBehaviour
{
    [Header("Configuraci�n del Pist�n")]
    public Transform piston; // Asigna el objeto del pist�n
    public float moveSpeed = 1.0f; // Velocidad de movimiento

    [Header("L�mites del Pist�n")]
    public float minHeight = -22.21f; // L�mite inferior (bajar)
    public float maxHeight = 0.05f; // L�mite superior (subir)

    private bool isMovingDown = false;
    private bool isMovingUp = false;

    void Update()
    {
        // Mover el pist�n hacia abajo
        if (isMovingDown && piston.localPosition.y > minHeight)
        {
            Vector3 newPosition = piston.localPosition;
            newPosition.y -= moveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Max(newPosition.y, minHeight); // Aplicar l�mite inferior
            piston.localPosition = newPosition;
        }

        // Mover el pist�n hacia arriba
        if (isMovingUp && piston.localPosition.y < maxHeight)
        {
            Vector3 newPosition = piston.localPosition;
            newPosition.y += moveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Min(newPosition.y, maxHeight); // Aplicar l�mite superior
            piston.localPosition = newPosition;
        }
    }

    // M�todos p�blicos para control desde los botones
    public void StartMovingDown()
    {
        isMovingDown = true;
        isMovingUp = false;
    }

    public void StopMovingDown()
    {
        isMovingDown = false;
    }

    public void StartMovingUp()
    {
        isMovingUp = true;
        isMovingDown = false;
    }

    public void StopMovingUp()
    {
        isMovingUp = false;
    }
}