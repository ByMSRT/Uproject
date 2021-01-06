using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Animations du perso
    Animation animations;

    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    // Variables concernant l'attaque
    public float attackCooldown;
    private bool isAttacking;
    private float currentCooldown;

    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputJump;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start() {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        
    }

    // Update is called once per frame
    void Update() {
            //si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,0, walkSpeed * Time.deltaTime);
            animations.Play("BasicMotions@Walk01");
        }
            //si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,0, runSpeed * Time.deltaTime);
            animations.Play("BasicMotions@Run01");
        }
            //si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("BasicMotions@RunBackwards01");
        }
            //si rotation à gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
            //si rotation à droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
