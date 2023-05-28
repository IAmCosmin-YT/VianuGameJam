using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    public static RuntimePlatform platform { get; private set; }
    [SerializeField] GameObject forPhone;

    private void Start()
    {
        platform = Application.platform;

        switch (platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                Debug.Log("Running on Windows");
                break;

            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                Debug.Log("Running on macOS");
                break;

            case RuntimePlatform.LinuxEditor:
            case RuntimePlatform.LinuxPlayer:
                Debug.Log("Running on Linux");
                break;

            case RuntimePlatform.Android:
                Debug.Log("Running on Android");
                break;

            case RuntimePlatform.IPhonePlayer:
                Debug.Log("Running on iOS");
                break;

            // Add more cases for other platforms if needed

            default:
                Debug.Log("Running on an unknown platform");
                break;
        }
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            forPhone.SetActive(true);
        }
        else forPhone.SetActive(false);
    }
}
