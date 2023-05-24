using System.Collections;  //Contains interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections.Generic;  //Contains interfaces and classes that define generic collections
using UnityEngine;  //this tells MonoDevelop that you are using Unity's version of C#

public class PlayerController : MonoBehaviour  //MonoBehaviour is the base class from which every Unity script derives.
{
    //Declare Variables
    //public - can be access by anyone anywhere. 
    //private - can only be accessed from with in the class it is a part of
    private CharacterController controller ;
    private Vector3 direction ; // vector3 ==> to pass 3D positions and directions around,it also contains functions for doing common vector operations.
    public float forwardSpeed; // the initial speed that increase in progress
    public float maxSpeed; // the maximum speed player has
    // desiredlane ==> to move player right and left
    private int desiredLane = 1;   //0:left  1:middle(default)  2:right
    public float laneDistance = 4; // the distance between two lanes
    public float jumpForce;
    public float Gravity = -20;
    private bool isSliding = false;
    public Animator animator; // variable for any animation
    
    void Start()
    {
        controller = GetComponent<CharacterController>();  //Gets a reference to the specified GameObject(CharacterController).
    }
//     // Update is called once per frame
    void Update() // A function with "void" just means that no data is returned
    {
        if(!PlayerManager.isGameStarted) // if game not started, not move
            return;
        if(forwardSpeed < maxSpeed) // to increase speed in progress
            forwardSpeed += 1.0f * Time.deltaTime; 
        animator.SetBool("isGameStarted", true); // to activate the animation of the wheele
        direction.z = forwardSpeed; // set a value of speed in unity app , used to make player go
        animator.SetBool("isGrounded",controller.isGrounded);
        // if player is on ground (in this we don't need gravity) , it able to jump upwards 
        // if player now is upward the ground(making jump,we need gravity to prevent player doing many ups and return ground after one jump)

        if(controller.isGrounded)
        {
            direction.y = -2;
            if(Input.GetKeyDown(KeyCode.UpArrow)) //refer to uparrow (from SwipeManager script)
            {  
               Jump();
            }
        }else
        {
            direction.y += Gravity * Time.deltaTime; 
        }
        // Gather the inputs on which lane we should be
        // to move the player to right
        if(Input.GetKeyDown(KeyCode.DownArrow) && !isSliding) // to enable player to move down
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) //refer to right arrow
        {
            desiredLane++;
            if (desiredLane == 3) // if player in right and click on rightarrow button, still in right
                desiredLane = 2;
        }
        // to move the player to left
         if (Input.GetKeyDown(KeyCode.LeftArrow)) // refer to left arrow
        {
            desiredLane--;
            if (desiredLane == -1) // if player in left and click on leftarrow button, still in left
                desiredLane = 0;
        }
        // calculate where we should be in the future(targetposition)
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0) // to move to left
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2) //to move to right
        {
            targetPosition += Vector3.right * laneDistance;
        }
        // to be in the initial place(in the center) , and to make player collides with any obstacle
        transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime); 
        controller.center = controller.center; 
    }
    private void FixedUpdate() //Update phase in the native player loop
    {
        if(!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime); 
        //fixedDeltaTime ==> The interval in seconds at which physics and other fixed frame rate updates are performed.
    }
    private void Jump() //method of jumping to define the force of jump
    {
        direction.y = jumpForce; // set a value of jumpforce in unity app 
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) //method to define when gameover appears, (hit is a parameter)
    {
        if (hit.transform.tag == "Obstacle") // we determine which model that make a player fails by change the tag of the model to be an obstacle
        {
            PlayerManager.gameOver = true; // in this case we call playermanager script to activate gameover
            FindObjectOfType<AudioManager>().PlaySound("GameOver"); // to play the sound GameOver  when player fails
        }
    }
    private IEnumerator Slide() // to enable player slide below obstacles
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}

