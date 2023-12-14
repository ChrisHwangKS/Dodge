using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ź�� �̵� �ӷ�
    public float m_Speed = 8f;

    // ź���� ������ٵ� ������Ʈ
    private Rigidbody _BulletRigidbody;

    private void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� ������ �Ҵ�
        _BulletRigidbody = GetComponent<Rigidbody>();

        // ������ �ٵ��� �ӵ� = ���� ����(z�� ����) * �̵� �ӷ�
        _BulletRigidbody.velocity = transform.forward * m_Speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    /// <summary>
    /// Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    /// </summary>
    /// <param name="other">�浹 ����� �ݶ��̴��� �޽��ϴ�.</param>
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if(other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� playerController ������Ʈ�� �������� �� �����ߴٸ�
            // Die() �޼��� ����
            if (playerController != null) playerController.Die();
        }
    }
}
