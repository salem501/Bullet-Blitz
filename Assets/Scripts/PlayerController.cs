using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float movSpeed = 7f;
    private Animator animator;
    private string IS_WALKING = "isWalking";
    public int maxHealth = 100;
    public float lastTimeHit;
    public float lastTimeHealed;
    public int points;
    public float health;
    public int level;
    public int lastLevelPoints = 0;
    public int lastLevelUpgrade;
    public int levelUp;
    public bool levelUpBool = false;

    private void Start() {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    private void Update() {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
        setLevel();
        Heal();
        Die();
    }

    private void setLevel() {
        if(points % 5 == 0 && points > lastLevelPoints) {
            level++;
            lastLevelPoints = points;
            levelUpBool = true;
        }
        levelUp = level - lastLevelUpgrade;
        levelUpBool = false;
    }

    private void Heal() {
        if ((Time.time - lastTimeHit > 8) && (health < maxHealth) && (Time.time - lastTimeHealed > 1)) {
            health += 10;
            lastTimeHealed = Time.time;
        }
    }

    void OnDisable() {
        PlayerPrefs.SetFloat("score", points);
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
        bool canMove = !Physics.Raycast(transform.position, moveDir, .7f);
        if (canMove) {
            transform.position += moveDir * Time.deltaTime * movSpeed;
        }
        
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

    private void Die() {
        if (health <= 0) {
            print("You died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
