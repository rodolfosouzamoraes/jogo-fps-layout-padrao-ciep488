using UnityEngine;
/// <summary>
/// Classe responsável por movimentar a camera do jogador
/// </summary>
public class MouseLookCtlr : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    Vector2 lastAxis;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LockAndHideMouse();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;   
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up*mouseX);

        HideOrShowMouse();
    }

    /// <summary>
    /// Exibe ou oculta o mouse
    /// </summary>
    void HideOrShowMouse(){
        /*if(PauseGameMng.Instance.IsPause){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{
            LockAndHideMouse();
        }*/
    }

    void LockAndHideMouse(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
