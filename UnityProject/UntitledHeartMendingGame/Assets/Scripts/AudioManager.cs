using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;

    public  static AudioManager Instance { get => _instance; set => _instance = value; }

    public List<AudioClip> clipList;
    AudioSource audioSource;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCollectible()
    {
        audioSource.clip = clipList[0];
        audioSource.Play();
    }

    public void PlayVictory()
    {
        audioSource.clip = clipList[1];
        audioSource.Play();
    }
}
