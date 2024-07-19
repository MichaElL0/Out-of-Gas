using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turnOn : MonoBehaviour
{
    public float time;
    public GameObject icon;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        icon.SetActive(true);
        audioSource.Play();


    }
}
