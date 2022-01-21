using UnityEngine;

public class MoveEngine : MonoBehaviour{
    [SerializeField] private CharacterController CC;

    [SerializeField] private float CrouchSpeed;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Gravity;
    [SerializeField] private bool isGrounded;
    public bool isRunning;
    public bool isMoving;

    [Header("ReadOnly")]
    [SerializeField] private float Speed;

    void Start() {
        Speed = WalkSpeed;
    }

    void Update() {
        if (!CC.isGrounded) {
            CC.Move(Vector3.down * Gravity * Time.deltaTime);
            isGrounded = false;
        } else {
            isGrounded = true;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)) {
            isMoving = true;
        } else {
            isMoving = false;
        }

        if(Input.GetKey(KeyCode.W)){
            CC.Move(transform.forward * Speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            CC.Move(-transform.forward * Speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            CC.Move(-transform.right * Speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            CC.Move(transform.right * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space)) {
            CC.Move(transform.up * JumpForce * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.CapsLock)) {
            Speed = RunSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.CapsLock)) {
            Speed = WalkSpeed;
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Speed = CrouchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            Speed = WalkSpeed;
        }
    }
}
