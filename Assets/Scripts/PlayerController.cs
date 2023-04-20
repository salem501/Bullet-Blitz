using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movSpeed = 5f;
    private Animator animator;
    private string IS_WALKING = "isWalking";

    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
    }

    void HandleMovementInput() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)) {
            animator.SetBool(IS_WALKING, true);
        }
        else {
            animator.SetBool(IS_WALKING, false);
        }

        

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime * movSpeed;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    void HandleRotationInput() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject childObject = transform.GetChild(2).GetChild(2).gameObject;
        Transform childTransform = childObject.GetComponent<Transform>();
        if (Physics.Raycast(ray, out hit)) {
            childTransform.LookAt(new Vector3(hit.point.x, childTransform.position.y, hit.point.z));
        }

    }

    void HandleShootInput() {
        if (Input.GetButton("Fire1")) {
            PlayerGun.Instance.Shoot();
        }
    }
}
