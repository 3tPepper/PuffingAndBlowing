using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    //�� �����Ӹ��� ����Ǵ� �޼ҵ�
    void FixedUpdate()
    {
        if (!isCatch)
        {
            PMove();
        }
    }

    private float pSpeed = 20f;
    public static bool isTouch = false;
    private bool isCatch = false;

    void PMove()
    {
        if(!EventSystem.current.IsPointerOverGameObject())  //���콺�� UI�� Ŭ������ ��� ������� �ʵ���
        {
            if (Input.GetMouseButton(0))    //���콺 ��Ŭ�� ���θ� ��ȯ
            {
                isTouch = true; //���콺 ��Ŭ���ϴ� ���̸�, food ��Ÿ������

                Vector3 nowpos = this.transform.position;    //���� ĳ������ ��ġ ��ǥ
                Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 10f));   //����ڰ� ��ġ�� ���� ��ġ ��ǥ
                Vector3 tmp = nowpos;
                newpos.z = 0f;  //z���� ������� �ʵ��� ���� 

                //nowpos�� newpos�� ��ġ�� ���Ͽ� ĳ���� �ִϸ��̼��� ���� �ֱ�
                if(nowpos.x > newpos.x) //left:1
                {
                    animator.SetInteger("move", 1);
                    tmp.x -= pSpeed * Time.deltaTime;
                    //this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                }
                else if(nowpos.x < newpos.x)    //right:2
                {
                    animator.SetInteger("move", 2);
                    tmp.x += pSpeed * Time.deltaTime;
                    //this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                }

                if(nowpos.y > newpos.y)
                {
                    tmp.y -= pSpeed * Time.deltaTime;
                }
                else if(nowpos.y < newpos.y)
                {
                    tmp.y += pSpeed * Time.deltaTime;
                }

                this.transform.position = tmp;
            }
            else
            {
                isTouch = false; //���콺 ��Ŭ���ϰ����� ���� ���, food ���������
                animator.SetInteger("move", 0);
            }
        }
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.tag == "Food")
        {
            isCatch = true;
            this.transform.position = collision.transform.position;
            animator.SetInteger("move", 3);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("exit");
        isCatch = false;
    }
}
