using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private GameObject PausePanel;

    public static bool isPause = false;

    void Start()
    {
        PausePanel.SetActive(false);
        hideFood();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
        if (PlayerMove.isTouch)
        {
            showFood();  //��ġ �����϶�
        }
        else
        {
            hideFood();  //��ġ ���°� �ƴҶ�
        }
    }

    //����ڰ� ��ġ �� ��ġ ������ food ������Ʈ Ȱ��ȭ.
    void showFood()
    {
        food.SetActive(true);   //food ������Ʈ�� Ȱ��ȭ
    }

    void hideFood()
    {
        food.SetActive(false);  //food ������Ʈ�� ��Ȱ��ȭ
    }

    public void GamePause()
    {
        isPause = !isPause;
        if (isPause)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
        
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
