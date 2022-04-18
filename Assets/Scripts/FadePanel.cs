using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class FadePanel : MonoBehaviour
{
    public int mode = 0;

    private Image _fade;

    public bool StartFade = false;
    private bool once = true;

    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;

    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Image>();
        _vignette = _postProcessVolume.profile.GetSetting<Vignette>();
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFade == true && once == true)
        {
            StartFade = false;
            once = false;
            switch (mode)
            {
                case 1:
                    StartCoroutine(FadeOut());
                    break;
                case 2:
                    StartCoroutine(FadeIn());
                    break;
                case 3:
                    StartCoroutine(FadeOutToIn());
                    break;
                default:
                    Debug.Log("Fade‚ÉŽ¸”s‚µ‚Ü‚µ‚½");
                    break;
            }
        }
    }

    private IEnumerator FadeOut()
    {
        _fade.color = new Color(0, 0, 0, 0);
        _vignette.intensity.value = 0f;
        yield return new WaitForSeconds(0.1f);

        for(int i = 0; i < 255; i++)
        {
            _fade.color = _fade.color + new Color(0, 0, 0, 1 / 255f);
            _vignette.intensity.value += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }
        once = true;
        _vignette.intensity.value = 0f;
        yield break;
    }

    private IEnumerator FadeIn()
    {
        _fade.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 255; i++)
        {
            _fade.color = _fade.color - new Color(0, 0, 0, 1 / 255f);
            yield return new WaitForSeconds(0.001f);
        }
        once = true;
        yield break;
    }

    private IEnumerator FadeOutToIn()
    {
        _fade.color = new Color(0, 0, 0, 0);
        _vignette.intensity.value = 0f;
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 255; i++)
        {
            _fade.color = _fade.color + new Color(0, 0, 0, 1 / 255f);
            _vignette.intensity.value += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }

        _fade.color = new Color(0, 0, 0, 1);
        _vignette.intensity.value = 0f;
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < 255; i++)
        {
            _fade.color = _fade.color - new Color(0, 0, 0, 1 / 255f);
            yield return new WaitForSeconds(0.001f);
        }
        once = true;
        yield break;
    }
}
