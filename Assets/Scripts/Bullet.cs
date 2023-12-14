using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 탄알 이동 속력
    public float m_Speed = 8f;

    // 탄알의 리지드바디 컴포넌트
    private Rigidbody _BulletRigidbody;

    private void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 변수에 할당
        _BulletRigidbody = GetComponent<Rigidbody>();

        // 리지드 바디의 속도 = 앞쪽 방향(z축 방향) * 이동 속력
        _BulletRigidbody.velocity = transform.forward * m_Speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    /// <summary>
    /// 트리거 충돌 시 자동으로 실행되는 메서드
    /// </summary>
    /// <param name="other">충돌 대상의 콜라이더를 받습니다.</param>
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 playerController 컴포넌트를 가져오는 데 성공했다면
            // Die() 메서드 실행
            if (playerController != null) playerController.Die();
        }
    }
}
