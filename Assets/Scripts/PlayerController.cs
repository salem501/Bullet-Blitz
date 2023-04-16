using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movSpeed = 2f;
    void Update() {
        HandleMovementInput();
        //HandleRotationInput();
        //HandleShootInput();
    }

    void HandleMovementInput() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.y = -1;
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

        if (Physics.Raycast(ray, out hit)) {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

    }

    void HandleShootInput() {
        if (Input.GetButton("Fire1")) {
            PlayerGun.Instance.Shoot();
        }
    }
}
