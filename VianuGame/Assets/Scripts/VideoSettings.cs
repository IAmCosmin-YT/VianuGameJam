using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppvolume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;
    private Bloom bloom;
    private MotionBlur motionBlur;
    private LensDistortion lensDistortion;
    [SerializeField] Animator cShake;

    [SerializeField] Toggle vignetteTog;
    [SerializeField] Toggle bloomTog;
    [SerializeField] Toggle chromTog;
    [SerializeField] Toggle motionblurTog;
    [SerializeField] Toggle lensTog;
    [SerializeField] Toggle fpsTog;
    [SerializeField] Toggle vsyncTog;
    [SerializeField] Toggle cShakeTog;

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

        LoadVar();
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
    public void ToggleVSync()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            PlayerPrefs.SetInt("vSync", 1);
            QualitySettings.vSyncCount = 1;
        }
        else
        { 
            PlayerPrefs.SetInt("vSync", 0);
            QualitySettings.vSyncCount = 0;

        }
    }
    public void ToggleCameraShake()
    {
        if (cShake != null)
        {
            cShake.enabled = !cShake.enabled;
            if (cShake.enabled)
                PlayerPrefs.SetInt("cShake", 1);
            else
                PlayerPrefs.SetInt("cShake", 0);
        }
        else
        {
            if (cShakeTog.isOn)
                PlayerPrefs.SetInt("cShake", 1);
            else
                PlayerPrefs.SetInt("cShake", 0);
        }
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
    public void LoadVar()
    {
        //show FPS
        fpsTog.isOn = IntToBool(PlayerPrefs.GetInt("fps"));

        //show Vignette
        vignetteTog.isOn = IntToBool(PlayerPrefs.GetInt("vignette"));
        vignette.enabled.value = vignetteTog.isOn;

        //toggle vsync
        vsyncTog.isOn = IntToBool(PlayerPrefs.GetInt("vSync"));
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("vSync");

        //toggle camera shake
        cShakeTog.isOn = IntToBool(PlayerPrefs.GetInt("cShake"));
        if (cShake != null)
            cShake.enabled = cShakeTog.isOn;

        //show Bloom
        bloomTog.isOn = IntToBool(PlayerPrefs.GetInt("bloom"));
        bloom.enabled.value = bloomTog.isOn;

        //show Chromatic Aberration
        chromTog.isOn = IntToBool(PlayerPrefs.GetInt("chromaticAberration"));
        chromaticAberration.enabled.value = chromTog.isOn;

        //show Lens Distortion
        lensTog.isOn = IntToBool(PlayerPrefs.GetInt("lensDistortion"));
        lensDistortion.enabled.value = lensTog.isOn;

        //show Motion Blur
        motionblurTog.isOn = IntToBool(PlayerPrefs.GetInt("motionBlur"));
        motionBlur.enabled.value = motionblurTog.isOn;

    }
}
