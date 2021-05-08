using System.Collections;
using UnityEngine;

public class AudioDestructBehaviour : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) Destroy(gameObject);
    }
}
