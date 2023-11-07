using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    
    public void PlaySparks()
    {
        _particles.Play();
    }
}
