using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private Vector2 moveDirection;
    private bool canMove = true;
    
    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        playerAnimator = this.GetComponent<Animator>();
        InputActions.MoveEvent += UpdateMoveVector;
    }

    private void UpdateMoveVector(Vector2 inputVector) // player input = moveVector(current vector2 from HandlePlayerMove)
    {
        if (canMove == true){
            moveDirection = inputVector;          
        }
        else{
            moveDirection = Vector2.zero; // stop player movement when not allowed to move
        }
    }

    void HandlePlayerMove(Vector2 moveVector) // use .Move functionality to move player on set veriables, gets updated by UpdateMoveVector() method
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate() // moving player by character controller component every frame
    {
        HandlePlayerMove(moveDirection);
    }

    public void SetCanMove(bool state){
        canMove = state; // set canMove to true or false depending on game state
        if (state == false) 
        {
            moveDirection = Vector2.zero; // stop player movement when not allowed to move
        }
    }

    private void OnDisable()
    {
        InputActions.MoveEvent -= UpdateMoveVector;
    }
}
