using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
  public Camera mainCamera;
  private CharacterController characterController = null;
  public float movementSpeed = 2.0f;
  public float rotationSensitivity = 1.0f;
  public float gravity = 20f;



  void Start() {
    characterController = GetComponent<CharacterController>();


  }

  void LateUpdate() {

#if UNITY_EDITOR
    if (Input.GetMouseButtonDown(0)) {
      SetCursorLock(true);
    } else if (Input.GetKeyDown(KeyCode.Escape)) {
      SetCursorLock(false);
    }
#endif  
    
    
    // Update the position.
    float movementX = Input.GetAxis("Horizontal");
    float movementY = Input.GetAxis("Vertical");
    Vector3 movementDirection = new Vector3(0.0f, 0.0f, movementY);
    
    
    transform.Rotate(new Vector3(0.0f,movementX*rotationSensitivity, 0.0f));

    movementDirection = transform.localRotation * movementDirection;
    movementDirection.y = 0.0f;
    movementDirection *= movementSpeed;
    
    movementDirection.y -= gravity * Time.deltaTime;
    characterController.Move(movementDirection * Time.deltaTime);
    
  }

  // Sets the cursor lock for first-person control.
  private void SetCursorLock(bool lockCursor) {
    if (lockCursor) {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    } else {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
  }
}

