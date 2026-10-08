using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // SerializeField me deja modificar la velocidad en el inspector de unity; lo demas permite el movimiento
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    //inputs de personaje
    private Vector2 moveInput;
    //animacion de personaje
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Control de cuerpo del personaje
        rb = GetComponent<Rigidbody2D>();
        //Control de animacion de personaje, configurar animator arriba
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

    }
    public void Move(InputAction.CallbackContext context)
    {
        //parte de walking animation
        animator.SetBool("isWalking", true);
        //esto va antes del moveInput para que lo lea bien
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);

        }
        //movimiento
        moveInput = context.ReadValue < Vector2>();
        //animacion
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
}
