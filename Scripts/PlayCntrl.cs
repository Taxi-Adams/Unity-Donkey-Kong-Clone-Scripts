using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCntrl : MonoBehaviour
{
    private CharacterController controller;
    public Animator anim;
    private bool grounded;
    private Vector3 playerVel;
    private Vector3 ladderVec = new Vector3(0, 0.2f, 0);
    private float horSpd = 5.4f;
    // private float verSpd = 2.5f;

    private float grav = -9.81f;
    private float jumpHght = 1.0f;
    private bool onGround =  true;
    private bool isDead = false;
    private bool canClimb = false;
    private bool zChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets horizontal and vertical input and sets the animators values equal to them
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Horizontal", horizontal);
        // Ensures the player doesn't fall through the ground
        if(!isDead) {
            grounded = isGrounded();
            if(grounded && playerVel.y < 0) {
                playerVel.y = 0;
            }

            // Moves the character horizontally based on input
            Vector3 move = new Vector3(horizontal, 0, 0);
            controller.Move(move * Time.deltaTime * horSpd);

            if(move != Vector3.zero) {
                gameObject.transform.forward = move;
            }
            // Allows the player to jump
            if(Input.GetButtonDown("Jump") && onGround) {
                playerVel.y += Mathf.Sqrt(jumpHght * -4.5f * grav);
                onGround = false;
                anim.SetBool("Jumping", !onGround);
            }
            // Climbs the ladder based on input
            if(Input.GetKey(KeyCode.UpArrow) && canClimb) {
                grav = 0.0f;
                controller.enabled = false;
                gameObject.transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime;
            } else {
                grav = -9.81f;
            }
            controller.enabled = true;

            playerVel.y += grav * Time.deltaTime;
            controller.Move(playerVel * Time.deltaTime);
        }
    }

    // Checks if the player collides with a barrel and triggers GameOver if so
    private void OnCollisionEnter(Collision collisionData) {
        if(!isDead) {
            if(collisionData.gameObject.tag == "Barrel") {
                isDead = true;
                anim.SetBool("Lost", true);
                GameControl.instance.playerDied();
                SceneManager.LoadScene(3);
            }
        }
    }

    // Checks if player comes into contact with any triggers and awards points, allows the player to climb ladders, and determines if the player wins
    private void OnTriggerEnter(Collider other) {
        if(!isDead) {
            if(other.gameObject.tag == "PointCollider") {
                GameControl.instance.playerScored();
                SceneManager.LoadScene(4);
            }
            if(other.gameObject.tag == "Ladder") {
                canClimb = true;
            }
            if(other.gameObject.tag == "WinTrigger") {
                anim.SetBool("Won", true);
                GameControl.instance.playerWon();
            }
        }
    }

    // Checks if the player leaves the ladder trigger collider to ensure the player cannot climb through steel beams/gain extra elevation when not climbing 
    private void OnTriggerExit(Collider other) {
        if(!isDead) {
            if(other.gameObject.tag == "Ladder") {
                Debug.Log("Leaving Ladder");
                canClimb = false;
            }
        }
    }

    // Checks if the player is grounded
    private bool isGrounded() {
        if(controller.isGrounded) {
            onGround = true;
            anim.SetBool("Jumping", !onGround);
        }
        return controller.isGrounded;
    }

    // Moves the player up the ladder
    private void climbLadder() {
        controller.Move(ladderVec * Time.deltaTime);
    }
}
