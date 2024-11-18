using UnityEngine;
/// <summary>
/// Classe responsável por movimentar o jogador
/// </summary>
public class PlayerMovimentCtlr : MonoBehaviour
{
    CharacterController controller;  
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;
    public bool isEnableJum = true;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(PauseGameMng.Instance.IsPause) return;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);
        
        if(Input.GetAxis("Jump")>0 && isGrounded && isEnableJum){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
        }

        velocity.y += gravity *Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
