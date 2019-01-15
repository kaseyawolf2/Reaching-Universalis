using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class Player : MonoBehaviour {

    #region Declerations
    //Keybinds
	KeyCode KbJump = Statics.KbJump;
	KeyCode KbInteract = Statics.KbInteract;


    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    float verticalRotation = 0;
    float upDownRange = 90.0f;
    public static Vector3 Currenttrans;
    float verticalVelocity = 0;

    //Jumping
    public int JumpHeight = 5;

    //Interaction
    public Camera Cam;
    
    //Raycasting
    RaycastHit hit;
    Ray ray;

    #endregion

    CharacterController characterController;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController> ();
        if (Camera.main == null) {
            print ("No camera");

        }

        Cam = Camera.main;

    }

    void Update () {

        if (Statics.ShowMouse == true) {
            Cursor.visible = true;
        }
        else {
            Cursor.visible = false;
        }

        #region Rotation/Movement
        // Rotation
        if (Statics.ShowMouse == false) {
            float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
            transform.Rotate (0, rotLeftRight, 0);
            verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
        }

        // Movement

        float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

        //Jumping
        if (characterController.isGrounded == false) {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else {
            verticalVelocity = Physics.gravity.y / 4;
            if (Input.GetKeyDown (KbJump)) {
                verticalVelocity = JumpHeight;
            }
        }

        Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.Move (speed * Time.deltaTime);

        #endregion


         #region Raycasting for Interactions
        return;
        if (Input.GetKeyDown(KbInteract) /*|| Statics.ShowMouse == true */ ) {
            GameObject Temp = RaycastTarget ();
            if(Temp != null){
                
            }
        }
        #endregion
     }
    GameObject RaycastTarget () {
        GameObject HitObj;
        ray = new Ray (Cam.transform.position, Cam.transform.forward);
        if (Physics.Raycast (ray, out hit, 2)) {
            HitObj = hit.transform.gameObject;
            //gameObject.GetComponent<Inventory> ().TarObj = HitObj;
            Debug.Log ("Hit : " + HitObj.name);
            return HitObj;
        }else{
            return null;
        }
    }
}