using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletSpawner : MonoBehaviour
{
    // 생성할 탄알의 원본 프리팹
    public GameObject m_bulletPrefab;

    // 최소 생성 주기
    public float m_spawnRateMin = 0.5f;

    // 최대 생성 주기
    public float m_spawnRateMax = 3f;

    // 발사할 대상
    private Transform _target;

    // 생성 주기
    private float _spawnRate;

    // 최근 생성 시점에서 지난 시간
    private float _timeAfterSpawn;

    private void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        _timeAfterSpawn = 0;

        // 탄알 생성 간격을 m_spawnRateMin 과 m_spawnRateMax 사이에서 랜덤 지정
        _spawnRate = Random.Range(m_spawnRateMin, m_spawnRateMax);

        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        _target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        // _timeAfterSpawn 갱신
        _timeAfterSpawn += Time.deltaTime;

        // 최근 생성 지점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(_timeAfterSpawn >= _spawnRate)
        {
            // 누적된 시간을 리셋
            _timeAfterSpawn = 0;

            // m_bulletPrefab 의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet 게임 오브젝트의 정면 방향이 _target을 향하도록 회전
            bullet.transform.LookAt(_target);

            // 다음번 생성 간격을 m_spawnRateMin 과 m_spawnRateMax 사이에서 랜덤 지정
            _spawnRate = Random.Range(m_spawnRateMin, m_spawnRateMax);

        }
    }
}
