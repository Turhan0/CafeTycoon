using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float footstepInterval = 0.4f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private float footstepTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	    animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused || !InventoryManager.menuActivated)
        {
        rb.linearVelocity = moveInput * moveSpeed;
        }
        HandleFootsteps();
    }

    void HandleFootsteps()
    {
        if (moveInput.magnitude > 0.1f)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0f)
            {
                AudioManager.Instance.PlayFootstepSound();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        if(PauseMenu.isPaused || InventoryManager.menuActivated)
        {
            return;
        }
	//animator.SetBool("isWalking", true);
    animator.SetBool("isWalking", moveInput.magnitude > 0.1f);

	if(context.canceled)
	{
	    animator.SetBool("isWalking", false);
	    animator.SetFloat("LastInputX", moveInput.x);
	    animator.SetFloat("LastInputY", moveInput.y);
	}
	
    moveInput = context.ReadValue<Vector2>();
	animator.SetFloat("InputX", moveInput.x);
	animator.SetFloat("InputY", moveInput.y);
    }
}
