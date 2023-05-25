using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    private static bool isPersisted = false;

    private void Awake()
    {
        if (!isPersisted)
        {
            DontDestroyOnLoad(gameObject);
            isPersisted = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
