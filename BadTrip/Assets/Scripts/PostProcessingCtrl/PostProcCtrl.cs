using System.Collections;
using UnityEngine;
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
    private Bloom bloom;

    // Start is called before the first frame update
    void Start()
    {
        foreach (VolumeComponent volumeComponent in volumeSettings.m_Profile.components) {
            if (volumeComponent.name == "ChromaticAberration") chromaticAberration = volumeComponent as ChromaticAberration;
            else if (volumeComponent.name == "FilmGrain") filmGrain = volumeComponent as FilmGrain;
            else if (volumeComponent.name == "LensDistortion") lensDistortion = volumeComponent as LensDistortion;
            else if (volumeComponent.name == "DepthOfField") depthOfField = volumeComponent as DepthOfField;
            else if (volumeComponent.name == "Bloom") bloom = volumeComponent as Bloom;
        }
    }

    public void OnHallucinationEffect() // 환각 효과 on
    {
        isPostON = true;

        chromaticAberration.intensity.overrideState = true;
        filmGrain.intensity.overrideState = true;
        lensDistortion.intensity.overrideState = true;
        depthOfField.mode.overrideState = true;
        bloom.intensity.overrideState = true;

        StartCoroutine(LensDistortion());
        StartCoroutine(DepthOfField());
        StartCoroutine(LensCenter());
    }
    public void OffHallucinationEffect() // 환각 효과 off
    {
        isPostON = false;

        StopAllCoroutines();

        lensDistortion.intensity.value = 0;
        depthOfField.gaussianMaxRadius.value = 0;

        chromaticAberration.intensity.overrideState = false;
        filmGrain.intensity.overrideState = false;
        lensDistortion.intensity.overrideState = false;
        depthOfField.mode.overrideState = false;
        bloom.intensity.overrideState = false;
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

}
