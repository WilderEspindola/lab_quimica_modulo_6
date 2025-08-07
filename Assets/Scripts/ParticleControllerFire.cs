using UnityEngine;
using TMPro;

public class ParticleControllerFire : MonoBehaviour
{
    [Header("Control de Fuego")]
    public ParticleSystem targetParticleSystemFire;

    [Header("Configuración de Temperatura")]
    public TextMeshProUGUI temperatureDisplay; // Asignar el texto "X (°K)"
    public float minTemperature = 298f; // 298K = 25°C
    public float maxTemperature = 800f; // 800K máximo
    public float heatingRate = 2f;     // Grados K por segundo al calentar
    public float coolingRate = 1f;     // Grados K por segundo al enfriar

    private float currentKelvin;
    private bool isHeating = false;

    void Start()
    {
        // Inicializar temperatura
        currentKelvin = minTemperature;
        UpdateTemperatureDisplay();
    }

    void Update()
    {
        if (isHeating)
        {
            // Modo calentamiento
            currentKelvin = Mathf.Min(currentKelvin + heatingRate * Time.deltaTime, maxTemperature);
        }
        else
        {
            // Modo enfriamiento
            currentKelvin = Mathf.Max(currentKelvin - coolingRate * Time.deltaTime, minTemperature);
        }

        UpdateTemperatureDisplay();
    }

    public void StartParticles()
    {
        if (targetParticleSystemFire != null)
        {
            targetParticleSystemFire.Play();
        }
        isHeating = true;
    }

    public void StopParticles()
    {
        if (targetParticleSystemFire != null)
        {
            targetParticleSystemFire.Stop();
        }
        isHeating = false;
    }

    private void UpdateTemperatureDisplay()
    {
        if (temperatureDisplay != null)
        {
            // Mostrar en formato "X (°K)"
            temperatureDisplay.text = $"{Mathf.RoundToInt(currentKelvin)} (°K)";

            // Cambiar color según temperatura
            float tempRatio = Mathf.InverseLerp(minTemperature, maxTemperature, currentKelvin);
            temperatureDisplay.color = Color.Lerp(Color.white, Color.red, tempRatio);
        }
    }

    // Método para acceder a la temperatura actual
    public float GetCurrentTemperature()
    {
        return currentKelvin;
    }
}