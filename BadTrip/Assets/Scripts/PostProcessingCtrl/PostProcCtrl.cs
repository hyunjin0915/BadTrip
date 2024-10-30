using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;

public class PostProcCtrl : MonoBehaviour
{
    bool isPostON = false;

        // 환각 작용 관련 변수
    public Cinemachine.PostFX.CinemachineVolumeSettings volumeSettings;
    private ChromaticAberration chromaticAberration;
    private FilmGrain filmGrain;
    private LensDistortion lensDistortion;
    private DepthOfField depthOfField;
    private Bloom bloom;
    private AnalogGlitchVolume agVolume;
    [SerializeField]
    private GameObject mask;
    [SerializeField]
    private SpriteRenderer maskSR;
    [SerializeField]
    private SpriteRenderer imageSR;

    // Start is called before the first frame update
    void Start()
    {

        foreach (VolumeComponent volumeComponent in volumeSettings.m_Profile.components) {
            if (volumeComponent.name == "ChromaticAberration") chromaticAberration = volumeComponent as ChromaticAberration;
            else if (volumeComponent.name == "FilmGrain") filmGrain = volumeComponent as FilmGrain;
            else if (volumeComponent.name == "LensDistortion") lensDistortion = volumeComponent as LensDistortion;
            else if (volumeComponent.name == "DepthOfField") depthOfField = volumeComponent as DepthOfField;
            else if (volumeComponent.name == "Bloom") bloom = volumeComponent as Bloom;
            else if (volumeComponent.name == "AnalogGlitchVolume") agVolume = volumeComponent as AnalogGlitchVolume;
        }
    }

    public void OnHallucinationEffect() // 환각 효과 on
    {
        isPostON = true;

        /*chromaticAberration.intensity.overrideState = true;
        filmGrain.intensity.overrideState = true;
        lensDistortion.intensity.overrideState = true;*/
        depthOfField.mode.overrideState = true;
        bloom.intensity.overrideState = true;
        agVolume.colorDrift.overrideState = true;

        //StartCoroutine(LensDistortion());
        StartCoroutine(DepthOfField());
        StartCoroutine(OnChromaticAberration());
        //StartCoroutine(OnMask());
        StartCoroutine(OnJitter(6, 3, 0.3f));
        //StartCoroutine(LensCenter());
    }
    public void OffHallucinationEffect() // 환각 효과 off
    {
        isPostON = false;

        StartCoroutine(OffChromaticAberration());
        //StartCoroutine(OffMask());

        //lensDistortion.intensity.value = 0;

        /*chromaticAberration.intensity.overrideState = false;
        filmGrain.intensity.overrideState = false;
        lensDistortion.intensity.overrideState = false;*//*
        depthOfField.gaussianMaxRadius.value = 0;
        depthOfField.mode.overrideState = false;
        bloom.intensity.overrideState = false;*/
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

    public IEnumerator LensDistortion()
    {
        float f = 0;
        bool isOn = true; // true : 내려가야 함. false : 올라가야 함

        while (f < 0.71)
        {
            f += 0.007f;
            lensDistortion.intensity.value = f;
            yield return null;
        }

        while (isPostON)
        {
            if (isOn)
            {
                f -= 0.007f;

                if (f <= -0.5f)
                {
                    isOn = false;
                }
            }
            else
            {
                f += 0.007f;

                if (f >= 0.7f)
                {
                    isOn = true;
                }
            }

            lensDistortion.intensity.value = f;
            yield return null;
        }
    }
    public IEnumerator DepthOfField()
    {
        float f = 0;
        bool isOn = false; // true : 내려가야 함. false : 올라가야 함

        while (f < 0.81f)
        {
            f += 0.01f;
            depthOfField.gaussianMaxRadius.value = f;
            yield return null;
        }

        while (isPostON)
        {
            if (isOn)
            {
                f -= 0.01f;

                if (f <= 0.8f)
                {
                    isOn = false;
                }
            }
            else
            {
                f += 0.01f;

                if (f >= 1.5)
                {
                    isOn = true;
                }
            }

            depthOfField.gaussianMaxRadius.value = f;

            yield return null;
        }
    }

    public IEnumerator LensCenter()
    {
        float xf = 0.5f;

        bool isOn = true; // true : 내려가야 함. false : 올라가야 함

        while (isPostON)
        {
            if (isOn)
            {
                xf -= 0.001f;

                if (xf <= 0.4f)
                {
                    isOn = false;
                }
            }
            else
            {
                xf += 0.001f;

                if (xf >= 0.6f)
                {
                    isOn = true;
                }
            }

            lensDistortion.center.value = new Vector2(xf, 0.5f);

            yield return null;
        }
    }

    public IEnumerator OnJitter(float wait, float term, float inte)
    {

        agVolume.scanLineJitter.overrideState = true;
        yield return new WaitForSeconds(wait);

        while (isPostON)
        {

            agVolume.scanLineJitter.value = inte;

            yield return new WaitForSeconds(term);

            agVolume.scanLineJitter.value = 0f;

            yield return new WaitForSeconds(term);
        }
    }

    public IEnumerator OnChromaticAberration()
    {
        float f = 0;
        
        while (f <= 0.6f)
        {
            f += 0.001f;

            agVolume.colorDrift.value = f;
            yield return null;
        }
    }

    public IEnumerator OffChromaticAberration()
    {
        float f = agVolume.colorDrift.value;

        while (f > 0f)
        {
            f -= 0.001f;

            agVolume.colorDrift.value = f;
            yield return null;
        }

        agVolume.colorDrift.overrideState = false;
        agVolume.colorDrift.value = 0;
    }

    public IEnumerator OnMask()
    {
        mask.SetActive(true);

        float f = 0;

        while (f < 1f)
        {
            maskSR.color = new Color(1, 1, 1, f);
            f += 0.01f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public IEnumerator OffMask()
    {
        float f = 16;

        while (f >= 0f)
        {
            f -= 0.01f;

            if (f <= 13f)
            {
                maskSR.material.SetFloat("_Scale", f);
            }
            maskSR.material.SetFloat("_Speed", f);
            yield return null;
        }

        maskSR.material.SetFloat("_Scale", 0);
        maskSR.material.SetFloat("_Speed", 0);

        mask.SetActive(false);
    }

    public void ShutDown() // 바로 끄기
    {
        StopAllCoroutines();
        
        maskSR.material.SetFloat("_Scale", 0);
        maskSR.material.SetFloat("_Speed", 0);
        mask.SetActive(false);

        agVolume.colorDrift.overrideState = false;
        agVolume.colorDrift.value = 0;

        agVolume.verticalJump.overrideState = false;
        agVolume.verticalJump.value = 0;

        agVolume.colorDrift.overrideState = false;
        agVolume.colorDrift.value = 0;

        agVolume.scanLineJitter.overrideState = false;
        agVolume.scanLineJitter.value = 0;

        depthOfField.gaussianMaxRadius.value = 0;
        depthOfField.mode.overrideState = false;
        bloom.intensity.overrideState = false;
    }

    public IEnumerator SetMask() // 정도 조절
    {
        float f = agVolume.colorDrift.value;

        while (f > 0.3f)
        {
            f -= 0.001f;
            
            agVolume.colorDrift.value = f;
            yield return null;
        }

        agVolume.colorDrift.value = 0.3f;
        agVolume.speed.value = 1f;
    }

    public IEnumerator PastHallucinationEffect()
    {
        isPostON = false;

        agVolume.verticalJump.overrideState = true;
        agVolume.verticalJump.value = 0;
        agVolume.scanLineJitter.value = 1;

        float f = 0;

        while (f < 1.0f)
        {
            f += 0.001f;

            agVolume.verticalJump.value = f;
            //agVolume.scanLineJitter.value = f;
            yield return null;
        }

        agVolume.verticalJump.overrideState = false;
        agVolume.verticalJump.value = 0;
    }

    public void OnRoomBloomEffect()
    {
        isPostON = true;

        bloom.intensity.overrideState = true;

        StartCoroutine(OnMask());
        mask.SetActive(true);
        maskSR.material.SetFloat("_Scale", 13);
        maskSR.material.SetFloat("_Speed", 16);
        StartCoroutine(OnImage());
        StartCoroutine(HomeBloomEffect());
    }

    // 방에서 처음 마약할 때
    public IEnumerator HomeBloomEffect()
    {
        float f = 0;

        while (f <= 1.4f)
        {
            f += 0.001f;

            bloom.intensity.value = f;
            yield return null;
        }
    }

    public void OffRoomBloomEffect()
    {
        isPostON = false;

        StopAllCoroutines();
        
        bloom.intensity.overrideState = false;
        bloom.intensity.value = 0;
        maskSR.material.SetFloat("_Scale", 0);
        maskSR.material.SetFloat("_Speed", 0);
        mask.SetActive(false);
    }

    public IEnumerator OnImage()
    {
        float f = 0;

        while (f <= 0.1f)
        {
            f += 0.005f;

            imageSR.color = new Color(1, 1, 1, f);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public void SetIsPostON(bool b)
    {
        isPostON=b;
    }

}
