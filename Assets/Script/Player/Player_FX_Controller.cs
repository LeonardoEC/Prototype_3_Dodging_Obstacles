using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FX_Controller : MonoBehaviour
{
    Dictionary<string, ParticleSystem> _playerParticleMap = new Dictionary<string, ParticleSystem>();

    private void Awake()
    {
        LoadParticles();
    }

    void LoadParticles()
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem particleSystem in particleSystems)
        {
            string particleName = particleSystem.name;
            if(!_playerParticleMap.ContainsKey(particleName))
            {
                _playerParticleMap.Add(particleName, particleSystem);
            }
        }
    }

    public void PlayPlayerParticle(string particleName)
    {
        if(_playerParticleMap.TryGetValue(particleName, out ParticleSystem particleSistems))
        {
            particleSistems.Play();
        }

        else
        {
            Debug.LogWarning($"Particle '{particleName}' not found.");
        }
    }

    public void StopPlayerParticle(string particleName)
    {
        if( _playerParticleMap.TryGetValue(particleName,out ParticleSystem particleSistems))
        {
            particleSistems.Stop();
        }
    }
}
