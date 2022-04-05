using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �÷��̾� �ִϸ�����(��ġ��)
    enum State
    {
        Idle,
        Sit,
        WalkForward,
        WalkLeft,
        WalkRight,
        AttackLeft,
        AttackRight,
        AttackCenter,
    }
    // ������Ʈ(��ġ��)
    State state;

    //void SetTrigger(State next, string)




    [SerializeField]
    public float jumpPower = 6;
    public float gravity = -9.8f;
    float yVelocity;
    public float speed = 5f;
    int jumpCount;
    public int maxJumpCount = 2;

    CharacterController cc;

    public GameObject UIinventory;


    // �ִϸ�����(��ġ��)
    Animator animator;

    void Start()
    {
        this.cc = gameObject.GetComponent<CharacterController>();

        // �ִϸ�����(��ġ��)
        animator = gameObject.GetComponent<Animator>();
    }


    // CameraRotate 1��Ī ����(��ġ��)
    float rx;
    float ry;
    public float rotSpeed = 200;

    // �̴ϸ� ������ΰ�?
    //public Transform minimap;


    void Update()
    {

        // �ִϸ�����(��ġ��)
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            animator.SetTrigger("WalkForward");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("WalkLeft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("WalkRight");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("WalkBack");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpSpace");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("JumpDouble");
        }



        // CameraTotete(��ġ��)
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;

       // transform.Rotate(Vector3.up, mx * 0.3f * 360 * Time.deltaTime);
        transform.Rotate(Vector3.up, my * 0.3f * 360 * Time.deltaTime);

        // rx = Mathf.Clamp(rx, -70, 70);

        // transform.eulerAngles = new Vector3(0, 0, 0);

        // �̴ϸ� �Ұ�?
        //minimap.eulerAngle = new Vector3(90, ry, 0);


        // ����ڰ� zŰ�� ������ "������"��� ��µȴ�.
        if (Input.GetKeyDown("z"))
        {
            //print("������");
        }
        // ����ڰ� ���콺 ���� Ű�� ������ "����"�̶�� ��µȴ�.
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("����");
        }

        if (cc.isGrounded)
        {
            jumpCount = 0;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }


        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (this.UIinventory.gameObject.activeSelf)
            {
                UIinventory.SetActive(false);
            }
            else
            {
                UIinventory.SetActive(true);
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);


        transform.position = transform.position + dir * speed * Time.deltaTime;

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        dir.Normalize();
        Vector3 velocity = dir * speed;

        velocity.y = yVelocity;

        cc.Move(velocity * Time.deltaTime);

        //�¿� ȸ��(����)
       // float q = Input.GetAxis("QE");
       // transform.Rotate(Vector3.up, q * 0.3f * 360 * Time.deltaTime);

    }
    public bool isDamageing;

    public void OnDamage()
    {
        this.isDamageing = true;
    }


}
