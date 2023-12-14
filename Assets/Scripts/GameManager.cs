using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� ������ Ȱ��ȭ �� �ؽ�Ʈ ���� ������Ʈ
    public GameObject m_gameoverText;

    // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public TMP_Text m_timeText;

    // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public TMP_Text m_recordText;

    // ���� �ð�
    private float _surviveTime;

    // ���� ���� ����
    private bool _IsGameover;

    private void Start()
    {
        // ���� �ð��� ���� ���� ���� �ʱ�ȭ
        _surviveTime = 0;

        _IsGameover = false;
    }

    private void Update()
    {
        // ���� ������ �ƴ� ����
        if(!_IsGameover)
        {
            // ���� �ð� ����
            _surviveTime += Time.deltaTime;

            // ������ ���� �ð��� m_timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            m_timeText.text = "Time : " + (int) _surviveTime;
        }
        // ���� �������
        else 
        {
            // R Ű�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    /// <summary>
    /// ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    /// </summary>
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        _IsGameover = true;

        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        m_gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if(_surviveTime > bestTime) 
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = _surviveTime;

            // ����� �ְ� ��� ���� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� m_recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        m_recordText.text = "Best Time : " + (int)bestTime; 
    }
}
