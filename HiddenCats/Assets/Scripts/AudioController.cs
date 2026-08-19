using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Master Volume Settings")]
    [SerializeField] string masterVolumeParameter = "MasterVolume";
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] float masterMultiplier = 30f;
    [SerializeField] Toggle masterToggle;

    private bool disableToggleEvent;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(HandleSliderValueChanged);
        masterToggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(masterVolumeParameter, masterSlider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        masterMixer.SetFloat(masterVolumeParameter, Mathf.Log10(value) * masterMultiplier);
        disableToggleEvent = true;
        masterToggle.isOn = masterSlider.value > masterSlider.minValue;
        disableToggleEvent = false;
    }

    private void HandleToggleValueChanged(bool enableSound)
    {
        if (disableToggleEvent)
        {
            return;
        }

        if (enableSound)
        {
            masterSlider.value = masterSlider.maxValue;
        }
        else
        {
            masterSlider.value = masterSlider.minValue;
        }
    }

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(masterVolumeParameter, masterSlider.value);
    }
}
