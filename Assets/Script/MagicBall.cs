using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    // ��ü�� ���� ã�Ƽ� �����Ѵ�
    // ���� ������ ��ü�� 3�� �ڿ� �������.
    // ��ü�� ���� ������ hp�� ���δ�
    // ���� �ı��Ǹ� ��ü�� ���� ����Ѵ�.
    // ���� ���� ���� �չ������� ������.


    IEnumerator Start()
    {
        yield return StartCoroutine("IEMoveUp");
        StartCoroutine("IEMoveAttack");
        yield return 0;
    }

    IEnumerator IEMoveUp()
    {
        //if(name.Contains("1"))

        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            transform.position += Vector3.up * 1 * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator IEMoveAttack()
    {
        // �¾ �� �ӷ��� ���ϰ� �ʹ�.
        //int rVelocity = Random.Range(0, 10);
        //if (rVelocity < 3)

        for (float t = 0; t <= 2.5f; t += Time.deltaTime)
        {

            GameObject target = GameObject.FindWithTag("Barbarian");
            if (target != null)
            {
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();
                transform.position += dir * 2 * Time.deltaTime;
                yield return 0;
            }
            else
            {

                transform.position += Vector3.forward * 3 * Time.deltaTime;
                yield return 0;

                Destroy(gameObject, 1);
                //print("�� �����");
            }
        }
    }
    public float rotSpeed = 0.5f;
    float currenTime;
    void Update()
    {
        currenTime += 360 * Time.deltaTime;
        transform.Rotate(Vector3.up, rotSpeed * 360 * Time.deltaTime);
    }



    public GameObject effectPrefabs;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.name.Contains("Barbarian"))
            {
                // ����Ʈ�� �����Ѵ�.
                //GameObject effect = Instantiate(effectPrefabs);
                //effect.transform.position = other.gameObject.transform.position;
                //effect.transform.forward = other.gameObject.transform.forward;


                EnemyHP ehp = other.gameObject.GetComponent<EnemyHP>();
                ehp.HP--;
                print("���� �������� �޾Ҵ�");
                if (ehp.HP <= 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);
            }
        }
    }
}

