using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRay : MonoBehaviour
{
    RaycastHit hitInfo;
    public float maxDistance = 3;

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� ��ư�� ������ �������� ������.
        if (Input.GetMouseButtonDown(0))
        {

            Debug.DrawRay(transform.position, transform.up * maxDistance, Color.blue, 1);
            if (Physics.Raycast(transform.position, transform.up, out hitInfo, maxDistance))
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
        }
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
