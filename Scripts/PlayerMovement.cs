using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 5f;
    public float sprintSpeed = 20f;
    public float normalSpeed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask roadMask;

    bool isRunning = false;
    bool isSprinting = false;

    public AudioSource audio;
    public AudioSource audioR;
    public AudioSource woodAudio;
    bool isGroundedRoad;
    bool isOnTheRoad;
	[HideInInspector]
    public bool isOnTheWood;

    Vector3 velocity;

    public bool trigger = false;



    // Update is called once per frame
    void Start()
    {
        controller = GetComponent<CharacterController>();
        movementSpeed = normalSpeed;
        isSprinting = false;

    }
    void Update()
    {
        
        //Check if is on the road
        isGroundedRoad = Physics.CheckSphere(groundCheck.position, groundDistance, roadMask);
        if(isGroundedRoad == true)
        {
            //print("On the road!");
            isOnTheRoad = true;

            
		}
        else
		{
            //print("Is not on the road!");
            isOnTheRoad = false;
        }

        
        if (isOnTheWood == true)
        {
            //print("On the wood!");
            isOnTheWood = true;


        }
        else
        {
            //print("Is not on the wood!");
            isOnTheWood = false;
        }
        




        //Move player
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);
        controller.Move(move * movementSpeed * Time.deltaTime);

        //Checking if player is running
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 )
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        //Stoping walking sound when sprinting
        if(isRunning == true && movementSpeed == 10f)
		{
            isSprinting = true;
            if (audio.isPlaying)
                audio.Stop();
            
        }
        else
		{
            isSprinting = false;
            //print(isSprinting);
        }

        
        if(trigger == true)
		{
            //Playing sprint sound
            if (Input.GetKeyDown(KeyCode.LeftShift) && isRunning == true)
            {
                movementSpeed = sprintSpeed;
                FindObjectOfType<AudioManager>().Play("Sprint");

            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning == true)
            {
                movementSpeed = normalSpeed;
                FindObjectOfType<AudioManager>().Stop("Sprint");

            }
            if (isSprinting = true && isRunning == false)
            {
                movementSpeed = normalSpeed;
                FindObjectOfType<AudioManager>().Stop("Sprint");

            }

            //Playing sprint sound on the road

            if (Input.GetKeyDown(KeyCode.LeftShift) && isRunning == true && isOnTheRoad == true)
            {
                movementSpeed = sprintSpeed;
                FindObjectOfType<AudioManager>().Play("Road sprint");


            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning == true)
            {
                movementSpeed = normalSpeed;
                FindObjectOfType<AudioManager>().Stop("Road sprint");

            }
            if (isSprinting = true && isRunning == false && isOnTheRoad == true)
            {
                movementSpeed = normalSpeed;
                FindObjectOfType<AudioManager>().Stop("Road sprint");
            }

            if (movementSpeed == 10f && isOnTheRoad == true)
            {
                FindObjectOfType<AudioManager>().Stop("Sprint");
            }

            if (movementSpeed == 10f && isOnTheRoad == true)
            {
                audioR.Stop();

            }

            if (movementSpeed == 10f && isOnTheRoad == false)
            {

            }

        }


        
        //Playing walk sound
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && isSprinting == false && isOnTheRoad == false && isOnTheWood == false)
		{
            if (!audio.isPlaying && isRunning == true && isSprinting == false)
                audio.Play();
        }
		else if(Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
		{
            if (audio.isPlaying)
                audio.Stop();
        }

        //Playing walk sound on the road
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && movementSpeed == 5 && isOnTheRoad == true)
        {   
            if (!audioR.isPlaying && isRunning == true && isSprinting == false  && isOnTheRoad == true)
                audioR.Play();
            
        }
        else if ((Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0) && isOnTheRoad == false)
        {
            if (audioR.isPlaying)
                audioR.Stop();
        }

        //Playing walk sound on the wood
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && movementSpeed == 5 && isOnTheWood == true)
        {

            if (!woodAudio.isPlaying && isRunning == true && isSprinting == false)
                woodAudio.Play();
        }
        else if (movementSpeed == 0  && isOnTheWood == false)
        {
            if(woodAudio.isPlaying)
            woodAudio.Stop();
        }
        else
		{
            woodAudio.Stop();
        }

        if(isRunning == true && isOnTheWood == false && isOnTheRoad == false)
		{
            woodAudio.Stop();
		}
        

        if (isRunning == false && isOnTheRoad == true) 
        {
            audioR.Stop();
        }
        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
