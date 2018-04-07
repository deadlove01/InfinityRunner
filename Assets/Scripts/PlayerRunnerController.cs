using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 5f;
    public float jumpSpeed = 5f;

    public float sideSpeed = 5f;
    public float leftLimit = -5f;
    public float rightLimit = 5f;

    public float laneStep = 3f;
    public float gravity = 20f;
    public float defaultJumpY = 1.25f;
    public float defaultJumpColliderHeight = 2.5f;
    public float jumpCenterY = 1.82f;
    public float jumpColliderHeight = 1.92f;

    public LayerMask groundLayer;

    private PlayerAnimController animController;
    private CharacterController charController;


    private bool isStarted = false;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Vector3 moveDirection = Vector3.zero;


    [SerializeField] private float checkLine = 1.5f;
    void Awake()
    {
        animController = GetComponent<PlayerAnimController>();
        charController = GetComponent<CharacterController>();

        isGrounded = true;
    }
	// Use this for initialization

	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (GameManager.Instance.gameover)
	        return;

	    if (isStarted)
	    {
	        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
	        {
	            isJumping = true;

                moveDirection.y = jumpSpeed;
	        }

	        float h = Input.GetAxis("Horizontal");
            moveDirection.x = h * sideSpeed;
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    moveDirection.x = -laneStep;
            //   }
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    moveDirection.x = laneStep;
            //}
        }
	    else
	    {
	        if (Input.GetKeyDown(KeyCode.Space))
	        {
	            isStarted = true;
                GameManager.Instance.HideGuidePanel();
                moveDirection = new Vector3(0, 0, runSpeed);
                animController.Run();
	        }

        }


	    PlayerMovement();


	}


    void PlayerMovement()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);
        if (isJumping)
        {
            animController.Jump();
            ChangeCollider(false);
            isJumping = false;
        }
        
        if (IsGrounded())
        {
            isGrounded = true;
            ChangeCollider(true);
        }
        else
        {
            isGrounded = false;
        }

      
    }


    void ChangeCollider(bool onTheGround)
    {
        var center = charController.center;
        if (onTheGround)
        {
            charController.center = new Vector3(center.x, defaultJumpY, center.z);
            charController.height = defaultJumpColliderHeight;
        }
        else
        {
            charController.center = new Vector3(center.x, jumpCenterY, center.z);
            charController.height = jumpColliderHeight;
            
        }
    }


    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * checkLine, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, checkLine, groundLayer))
        {
            isGrounded = true;
            return true;
        }
        return false;
      
    }

    public void PlayerDie()
    {
        animController.Die();
    }
    
}
