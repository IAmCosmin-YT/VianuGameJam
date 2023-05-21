using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppvolume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;
    private Bloom bloom;
    private MotionBlur motionBlur;
    private LensDistortion lensDistortion;

    [SerializeField] Toggle vignetteTog;
    [SerializeField] Toggle bloomTog;
    [SerializeField] Toggle chromTog;
    [SerializeField] Toggle motionblurTog;
    [SerializeField] Toggle lensTog;
    [SerializeField] Toggle fpsTog;

    [SerializeField] Text fpsText;
    private float deltaTime = 0.0f;

    private bool IntToBool(int i)
    {
        if(i == 1)
        {
            return true;
        }
        else if(i == 0)
        {
            return false;
        }
        return false;
    }

    private void Update()
    {
        showFPS();
    }

    private void Start()
    {
        ppvolume = GameObject.FindGameObjectWithTag("ppvol").GetComponent<PostProcessVolume>();

        ppvolume.profile.TryGetSettings(out vignette);
        ppvolume.profile.TryGetSettings(out chromaticAberration);
        ppvolume.profile.TryGetSettings(out bloom);
        ppvolume.profile.TryGetSettings(out motionBlur);
        ppvolume.profile.TryGetSettings(out lensDistortion);

        fpsTog.isOn = IntToBool(PlayerPrefs.GetInt("fps"));
        vignetteTog.isOn = IntToBool(PlayerPrefs.GetInt("vignette"));
        bloomTog.isOn = IntToBool(PlayerPrefs.GetInt("bloom"));
        chromTog.isOn = IntToBool(PlayerPrefs.GetInt("chromaticAberration"));
        lensTog.isOn = IntToBool(PlayerPrefs.GetInt("lensDistortion"));
        motionblurTog.isOn = IntToBool(PlayerPrefs.GetInt("motionBlur"));
    }

    public void ToggleVignette()
    {
        vignette.enabled.value = !vignette.enabled.value;
        if (vignette.enabled)
            PlayerPrefs.SetInt("vignette", 1);
        else
            PlayerPrefs.SetInt("vignette", 0);
    }

    public void ToggleChromaticAberration()
    {
        chromaticAberration.enabled.value = !chromaticAberration.enabled.value;
        if (chromaticAberration.enabled)
            PlayerPrefs.SetInt("chromaticAberration", 1);
        else
            PlayerPrefs.SetInt("chromaticAberration", 0);
    }

    public void ToggleBloom()
    {
        bloom.enabled.value = !bloom.enabled.value;
        if (bloom.enabled)
            PlayerPrefs.SetInt("bloom", 1);
        else
            PlayerPrefs.SetInt("bloom", 0);
    }

    public void ToggleMotionBlur()
    {
        motionBlur.enabled.value = !motionBlur.enabled.value;
        if (motionBlur.enabled)
            PlayerPrefs.SetInt("motionBlur", 1);
        else
            PlayerPrefs.SetInt("motionBlur", 0);
    }

    public void ToggleLensDistortion()
    {
        lensDistortion.enabled.value = !lensDistortion.enabled.value;
        if (lensDistortion.enabled)
            PlayerPrefs.SetInt("lensDistortion", 1);
        else
            PlayerPrefs.SetInt("lensDistortion", 0);
    }
    public void showFPS()
    {
        if (fpsTog.isOn)
        {
            // Calculate frames per second
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            fpsText.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
            PlayerPrefs.SetInt("fps", 1);
        }
        else PlayerPrefs.SetInt("fps", 0);
        fpsText.gameObject.SetActive(fpsTog.isOn);
    }
}
