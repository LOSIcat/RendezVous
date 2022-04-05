using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRay : MonoBehaviour
{

    private Animator ani;
    RaycastHit hitInfo;
    public float maxDistance = 3;
    bool isAttack;
    public Transform rayTarget;

    private void Start()
    {
        this.ani = this.GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
  
            //���콺 ���� ��ư�� ������ �������� ������.
     if (Input.GetMouseButtonDown(0) && !isAttack)
        {

                isAttack = true;
            this.ani.SetTrigger("Attack");


            Debug.DrawRay(rayTarget.position, transform.forward * maxDistance, Color.blue, 1);
            if (Physics.Raycast(rayTarget.position, transform.forward, out hitInfo, maxDistance))
            {
                hitInfo.transform.GetComponent<BoxCollider>();
                print("���̰� ����Ǿ���");

                if (hitInfo.collider.gameObject.CompareTag("Barbarian"))
                {
                    EnemyHP ehp = hitInfo.transform.GetComponent<EnemyHP>();
                    ehp.HP--;
                    print("���� �������� �޾Ҵ�");
                    if (ehp.HP <= 0)
                    {
                        Destroy(hitInfo.transform.gameObject);
                    }
                }


                //�ִϸ����� SetƮ���� Attack 



                //if (hitInfo.collider.gameObject.Tag =="Barbarian")
                //if (hitInfo.collider.gameObject.CompareTag("Barbarian"))
                //{

                //    EnemyHP ehp = this.gameObject.GetComponent<EnemyHP>();
                //    ehp.HP--;
                //    print("���� Į�� �¾Ҵ�");
                //    if (ehp.HP <= 0)
                //    {
                //        Destroy(this.gameObject);
                //        print("���� Į�� �°� ����ߴ�");
                //    }
                //}


            }
            StartCoroutine(OnisAttack());
          
       
        }
    }


    IEnumerator OnisAttack()
    {
        yield return new WaitForSeconds(2f);
        isAttack = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {

            if (other.gameObject.name.Contains("Barbarian"))
            {

                EnemyHP ehp = other.gameObject.GetComponent<EnemyHP>();
                ehp.HP--;
                print("���� �������� �޾Ҵ�");
                if (ehp.HP <= 0)
                {
                    Destroy(other.gameObject);


                }
                //Destroy(this.gameObject);
                ////����Ʈ�� �����Ѵ�.
                //GameObject effect = Instantiate(effectPrefabs);
                //effect.transform.position = other.gameObject.transform.position;
                //effect.transform.forward = other.gameObject.transform.forward;

            }
        }
    }
}
