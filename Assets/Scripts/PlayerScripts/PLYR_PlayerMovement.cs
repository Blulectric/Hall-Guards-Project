using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYR_PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float maxSpeed = 12f;
    public float speed = 12f;
    public float gravity = 1.962f;

    public float mouseSensitivity = 100f;

    public Transform playerCamera;

    private float xRotation = 0f;

    public bool crouching = false;

    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ///////movement///////
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z + transform.up * -gravity;
        controller.Move(move * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.timeScale;// removed deltatime bacuse lag spikes would cause the camera to jolt really badly, timescale still lets the camera be frozen when game is paused
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity* Time.timeScale;

        if (Input.GetKeyDown("left ctrl"))
        {
            bool hitsHead = false;


            // cast a ray when trying to exit a crouch to check if player will hit their head
            RaycastHit hit;
            if (crouching && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 3f, -9))
            {
                hitsHead = true;
            }

            if (!hitsHead) // dont uncrouch if player would hit their head on something 
            {
            crouching = !crouching;
            t = 0;
            }


        }

        if (crouching)
        {
            t += 0.5f * Time.deltaTime;
            speed = maxSpeed / 3;
            gameObject.transform.localScale = new Vector3(1, Mathf.Lerp(gameObject.transform.localScale.y, 0.3f, t), 1);
        }
        else
        {
            t += 0.5f * Time.deltaTime;
            speed = maxSpeed;
            gameObject.transform.localScale = new Vector3(1, Mathf.Lerp(gameObject.transform.localScale.y, 1.0f, t), 1);
        }


        if (Input.GetMouseButtonDown(0) && WLD_RunGunTrigger.GENOCIDE == true)
        {
            // cast a ray when trying to exit a crouch to check if player will hit their head
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.TransformDirection(Vector3.forward), out hit, 100f))
            {
                Debug.DrawRay(playerCamera.position, playerCamera.TransformDirection(Vector3.forward), Color.red);
                Debug.Log(hit.transform.name+"shoot ray, though enemies are currently set to ignore raycast.. oops");
            }
        }

            ///////camera///////
            xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

 

    }
}