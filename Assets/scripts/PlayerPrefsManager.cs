using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "masterVolume";
	// Use this for initialization
	public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat("masterVolume", volume);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
}
