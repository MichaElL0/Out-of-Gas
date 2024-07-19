using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;

    public Transform playerbody;

    float xRotation = 0;

    public LayerMask mask;

    public Image dot;

    public GameObject note;

    private bool isNoteActive = false;

    public GameObject noteObject;

    public Animator animator;

    public bool noteBool;

    public doorOpenORClosed doorBool;

    public bool trigerbool = false;

    public GameObject writing;
    public GameObject car;
    public GameObject car2;
    public GameObject moon;

    public AudioSource openDoor;
    public AudioSource closeDoor;
    public AudioSource noteSFX;
    public AudioSource noteClose;
    public AudioSource ambience;
    public AudioSource afterAmbience;

    public PlayerMovement player;

    public GameObject blockWall;
    public GameObject endWall;
    public GameObject wall;
    public GameObject cube;

    public GameObject otherEndingWall;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        noteBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(note.activeSelf == true)
		{
            isNoteActive = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                note.SetActive(false);
                noteClose.Play();
                Time.timeScale = 1;
                trigerbool = false;
                Destroy(noteObject);
                writing.SetActive(true);
                Destroy(car);
                car2.SetActive(true);
                moon.SetActive(false);
                player.trigger = true;
                ambience.Stop();
                afterAmbience.Play();
                blockWall.SetActive(true);
                endWall.SetActive(true);
                wall.SetActive(false);
                cube.SetActive(true);
                otherEndingWall.SetActive(false);
            }

        }
        else
		{
            isNoteActive = false;
		}
        //print(isNoteActive);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerbody.Rotate(Vector3.up * mouseX);

        //Looking at objects

        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {

            var obj = hit.collider.gameObject;
            float dist = Vector3.Distance(obj.transform.position, transform.position);

            if (dist < 3)
			{
                if(Input.GetMouseButtonDown(0) && obj.tag == "Note")
				{
                    noteSFX.Play();
                    print("Take note");
                    note.SetActive(true);
                    isNoteActive = true;
                    Time.timeScale = 0;
                }
                else if(Input.GetMouseButtonDown(0) && obj.tag == "Door")
				{
                    if(trigerbool == false)
					{
                        animator.ResetTrigger("closeDoor");
                        animator.SetTrigger("openDoor");
                        openDoor.Play();
                        StartCoroutine(Wait());
                    }
                    
                    
					
				}

                ChangeDot();
            }          
            else if(dist > 3)
            {
                DeafultDot();
            }
        }
        else
		{
            DeafultDot();
        }
        
    }

    void ChangeDot()
	{
        //dot.localScale = new Vector3(2, 2, 1);
        dot.color = new Color32(183, 0, 0, 255);
    }

    void DeafultDot()
	{
        //dot.localScale = new Vector3(1, 1, 1);
        dot.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator Wait()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        animator.SetTrigger("closeDoor");
        closeDoor.Play();   
        //trigerbool = true;


    }
}
