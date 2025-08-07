using UnityEngine;

public class ParticleControllerWater : MonoBehaviour
{
    public ParticleSystem targetParticleSystem; // Nombre m�s espec�fico

    public void StartParticles()
    {
        if (targetParticleSystem != null)
        {
            targetParticleSystem.Play();
        }
    }

    public void StopParticles()
    {
        if (targetParticleSystem != null)
        {
            targetParticleSystem.Stop();
        }
    }
}
