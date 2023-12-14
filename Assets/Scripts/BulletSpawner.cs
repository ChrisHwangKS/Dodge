using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletSpawner : MonoBehaviour
{
    // ������ ź���� ���� ������
    public GameObject m_bulletPrefab;

    // �ּ� ���� �ֱ�
    public float m_spawnRateMin = 0.5f;

    // �ִ� ���� �ֱ�
    public float m_spawnRateMax = 3f;

    // �߻��� ���
    private Transform _target;

    // ���� �ֱ�
    private float _spawnRate;

    // �ֱ� ���� �������� ���� �ð�
    private float _timeAfterSpawn;

    private void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        _timeAfterSpawn = 0;

        // ź�� ���� ������ m_spawnRateMin �� m_spawnRateMax ���̿��� ���� ����
        _spawnRate = Random.Range(m_spawnRateMin, m_spawnRateMax);

        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        _target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        // _timeAfterSpawn ����
        _timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(_timeAfterSpawn >= _spawnRate)
        {
            // ������ �ð��� ����
            _timeAfterSpawn = 0;

            // m_bulletPrefab �� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);

            // ������ bullet ���� ������Ʈ�� ���� ������ _target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(_target);

            // ������ ���� ������ m_spawnRateMin �� m_spawnRateMax ���̿��� ���� ����
            _spawnRate = Random.Range(m_spawnRateMin, m_spawnRateMax);

        }
    }
}
