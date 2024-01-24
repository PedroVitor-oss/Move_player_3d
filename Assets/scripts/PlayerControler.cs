using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("atributos")]
    public float speed;
    public float jumpForce;
    private float vida = 10;

    [Header("components")]
    private Animator ani;
    private Rigidbody rig;
    
    [Header("gameObjetos")]
    public GameObject torso;


    [Header("input")]
    public float VerticalInput,HorizontalInput;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");

        // ani.SetBool("run",VerticalInput!=0);
        ani.SetFloat("veloVertical", ((VerticalInput<0) ? -1 : (VerticalInput==0) ? 0f : 1.0f));
        ani.SetFloat("veloHorizontal", ((HorizontalInput<0) ? -1 : (HorizontalInput==0) ? 0f : 1.0f));
    }
    private void FixedUpdate() {
        Move();
    }
    private void Move(){
        float vy = rig.velocity.y;
        Vector3 moveForward =  transform.forward * VerticalInput * speed * Time.fixedDeltaTime;
        Vector3 moveRight =  transform.right * HorizontalInput * speed * Time.fixedDeltaTime;

        Vector3 move;
        if(VerticalInput != 0){
            move = moveForward /*+ moveRight*/;//adicionar o movimento lateral usando o horizontal input
        }else{
            move = moveRight;
        }
        move.y = vy;

        rig.velocity =  move;
    }
}
