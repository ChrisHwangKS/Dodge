using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    private Rigidbody _PlayerRigidbody;

    // ���� �Ŵ��� ������Ʈ
    private GameManager _gameManager;

    // �÷��̾� �̵� �ӷ�
    public float m_Speed = 8f;

    private void Start()
    {
        // ���� �������Ϳ��� Rigidbody ������Ʈ�� ã�� ������ �Ҵ�
        _PlayerRigidbody = GetComponent<Rigidbody>();

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * m_Speed;
        float zSpeed = zInput * m_Speed;

        // Vector3 �ӵ��� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        // ������ٵ��� �ӵ��� �Ҵ�
        _PlayerRigidbody.velocity = newVelocity;
    }

    /// <summary>
    /// �÷��̾ ź�˿� �浹 �� �߻��� ��� �޼���
    /// </summary>
    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // GameManager ���� ��Ʈ�� EndGame() �޼��� ����
        _gameManager.EndGame();
    }
}
