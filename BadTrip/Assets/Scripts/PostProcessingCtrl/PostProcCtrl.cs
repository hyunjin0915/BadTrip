using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class PostProcCtrl : MonoBehaviour
{
        // 환각 작용 관련 변수
    public Cinemachine.PostFX.CinemachineVolumeSettings volumeSettings;
    private ChromaticAberration chromaticAberration;
    private FilmGrain filmGrain;
    private LensDistortion lensDistortion;
    private DepthOfField depthOfField;

    // Start is called before the first frame update
    void Start()
    {
        foreach (VolumeComponent volumeComponent in volumeSettings.m_Profile.components) {
            if (volumeComponent.name == "ChromaticAberration") chromaticAberration = volumeComponent as ChromaticAberration;
            else if (volumeComponent.name == "FilmGrain") filmGrain = volumeComponent as FilmGrain;
            else if (volumeComponent.name == "LensDistortion") lensDistortion = volumeComponent as LensDistortion;
            else if (volumeComponent.name == "DepthOfField") depthOfField = volumeComponent as DepthOfField;
        }
    }

    public void OnHallucinationEffect() // 환각 효과 on
    {
        // 후에 내용 추가
        // 여기에 환각 작용 적용 내용 추가
        chromaticAberration.intensity.overrideState = true;
        filmGrain.intensity.overrideState = true;
        lensDistortion.intensity.overrideState = true;
        depthOfField.mode.overrideState = true;
        Debug.Log("환각 효과 ON");
    }
    public void OffHallucinationEffect() // 환각 효과 off
    {
        // 후에 내용 추가
        // 여기에 환각 작용 취소 내용 추가
        chromaticAberration.intensity.overrideState = false;
        filmGrain.intensity.overrideState = false;
        lensDistortion.intensity.overrideState = false;
        depthOfField.mode.overrideState = false;
        Debug.Log("환각 효과 OFF");
    }

}
