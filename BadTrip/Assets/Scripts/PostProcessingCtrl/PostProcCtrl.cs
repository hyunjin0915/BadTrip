using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class PostProcCtrl : MonoBehaviour
{
    bool isPostON = false;

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
        isPostON = true;

        chromaticAberration.intensity.overrideState = true;
        filmGrain.intensity.overrideState = true;
        lensDistortion.intensity.overrideState = true;
        depthOfField.mode.overrideState = true;
        StartCoroutine(FadeIn());
    }
    public void OffHallucinationEffect() // 환각 효과 off
    {
        isPostON = false;
        chromaticAberration.intensity.overrideState = false;
        filmGrain.intensity.overrideState = false;
        lensDistortion.intensity.overrideState = false;
        depthOfField.mode.overrideState = false;
    }

    private IEnumerator RepeatFade()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator FadeIn()
    {
        float f = 0;

        while(f<=1)
        {
            f += 0.01f;
            chromaticAberration.intensity.value = f;
            filmGrain.intensity.value = f;
            if(f<=0.6)
            {
              lensDistortion.intensity.value = f;
            }
            //depthOfField.intensity.value = f;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        float f = 1;

        while(f>0)
        {
            f -= 0.01f;
            chromaticAberration.intensity.value = f;
            filmGrain.intensity.value = f;
            if(f<=0.6)
            {
              lensDistortion.intensity.value = f;
            }
            //depthOfField.intensity.value = f;
            yield return null;
        }
    }
}
