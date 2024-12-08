using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    public void SetMusicVolume()
    {
        float masterVolume = masterSlider.value;
        mixer.SetFloat("master", Mathf.Log10(masterVolume) * 20f);
    }
}
