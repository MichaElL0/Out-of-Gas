using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    //public GameObject flashlightLight;
    //private bool flashlightEnabled = false;

    private Vector3 vectOffset;
    private GameObject goFollow;
    public float speed = 3f;


    // Start is called before the first frame update
    void Start()
    {

        goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;


        //flashlightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = goFollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);



        /*
        if (Input.GetKeyUp(KeyCode.F))
		{
            if(flashlightEnabled == false)
			{
                flashlightLight.gameObject.SetActive(true);
                flashlightEnabled = true;
                
            }
            else
			{
                flashlightLight.gameObject.SetActive(false);
                flashlightEnabled = false;
            }
		}*/
    }
}
