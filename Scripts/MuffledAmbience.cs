using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffledAmbience : MonoBehaviour
{
    public AudioSource ambience;
    public AudioSource ambience2;
    public AudioLowPassFilter filter;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
            player.isOnTheWood = true;
            ambience.volume = 0.4f;
            ambience2.volume = 0.3f;
            filter.cutoffFrequency = 6007.7f;

        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
        {
            print("MUFFLE");
            ambience.volume = 0.8f;
            ambience2.volume = 0.6f;
            filter.cutoffFrequency = 22000f;
            player.isOnTheWood = false;

        }
    }
}
