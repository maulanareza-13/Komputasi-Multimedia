using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer myMixer;

    private GameObject panel;

    private bool isPaused = false;

    void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeInHierarchy);
            if (isPaused)
                Time.timeScale = 1.0f;
            else
                Time.timeScale = 0.0f;
            isPaused = !isPaused;
        }
    }

    public void ChangeMusicVol(float vol)
    {
        myMixer.SetFloat("MusicVolume", Mathf.Log10(vol) * 20f);
    }

    public void ChangeFxVol(float vol)
    {
        myMixer.SetFloat("FxVolume", Mathf.Log10(vol) * 20f);
    }

    public void ChangeOverallVol(float vol)
    {
        myMixer.SetFloat("OverallVolume", Mathf.Log10(vol) * 20f);
    }
}
