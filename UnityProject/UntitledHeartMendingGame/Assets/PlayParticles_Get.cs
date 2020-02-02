using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles_Get : MonoBehaviour
{
    public ParticleSystem KokoroGet;

    private void Awake()
    {
        KokoroGet = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player found");
            KokoroGet.Play();
        }
    }

}
