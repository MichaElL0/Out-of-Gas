using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu : MonoBehaviour
{
	public AudioMixer audioMixer;

    public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

    public void Play()
	{
        SceneManager.LoadScene("cutscene");
	}

	
}
