using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody _PlayerRigidbody;

    // 게임 매니저 오브젝트
    private GameManager _gameManager;

    // 플레이어 이동 속력
    public float m_Speed = 8f;

    private void Start()
    {
        // 게임 오브젝터에서 Rigidbody 컴포넌트를 찾아 변수에 할당
        _PlayerRigidbody = GetComponent<Rigidbody>();

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * m_Speed;
        float zSpeed = zInput * m_Speed;

        // Vector3 속도를 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        // 리지드바디의 속도에 할당
        _PlayerRigidbody.velocity = newVelocity;
    }

    /// <summary>
    /// 플레이어가 탄알에 충돌 시 발생할 사망 메서드
    /// </summary>
    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // GameManager 오브 젝트의 EndGame() 메서드 실행
        _gameManager.EndGame();
    }
}
