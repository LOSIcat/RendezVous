using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallAttack : MonoBehaviour
{
    public GameObject magicBallFactory;
    public GameObject targetPosition1;
    public GameObject targetPosition2;
    public GameObject targetPosition3;

    void Update()
    {
        // ������� �Է¿� ����
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��ü���忡�� ��ü�� ����
            GameObject magicBall1 = Instantiate(magicBallFactory);
            GameObject magicBall2 = Instantiate(magicBallFactory);
            GameObject magicBall3 = Instantiate(magicBallFactory);
            // Ÿ����ġ�� ����ʹ�.
            magicBall1.transform.position = targetPosition1.transform.position;
            //print("1��");
            magicBall2.transform.position = targetPosition2.transform.position;
            //print("2��");
            magicBall3.transform.position = targetPosition3.transform.position;
            //print("3��");
        }
    }
}
