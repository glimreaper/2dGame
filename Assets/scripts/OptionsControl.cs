using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsControl : MonoBehaviour {
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider effectsVolume;

	// Use this for initialization
	void Start () {
        masterVolume.value = PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(masterVolume.value);
    }
}
