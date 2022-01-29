using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    //�ʱ⿡ ����Ǵ� �޼ҵ�
    void Awake()
    {
        
    }

    //�� �����Ӹ��� ����Ǵ� �޼ҵ�
    void FixedUpdate()
    {
        PMove();
    }

    private float pSpeed = 0.2f;
    void PMove()
    {
        if(!EventSystem.current.IsPointerOverGameObject())  //���콺�� UI�� Ŭ������ ��� ������� �ʵ���
        {
            if (Input.GetMouseButton(0))    //���콺 ��Ŭ�� ���θ� ��ȯ
            {
                Vector3 nowpos = this.transform.position;    //���� ĳ������ ��ġ ��ǥ
                Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //����ڰ� ��ġ�� ���� ��ġ ��ǥ
                newpos.z = 0f;  //z���� ������� �ʵ��� ���� 
                this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                //todo: nowpos�� newpos�� ��ġ�� ���Ͽ� ĳ���� �ִϸ��̼��� ���� �ֱ�
            }
        }
        
    }
}
