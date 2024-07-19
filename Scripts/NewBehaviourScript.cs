using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Light lightC;
    public Transform lightT;
    public Transform camT;
    public float t;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightT.position = Vector3.Slerp(lightT.position, camT.position, t);
        lightT.rotation = Quaternion.Slerp(lightT.rotation, camT.rotation, t);
    }
}
