using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 오버시 활성화 할 텍스트 게임 오브젝트
    public GameObject m_gameoverText;

    // 생존 시간을 표시할 텍스트 컴포넌트
    public TMP_Text m_timeText;

    // 최고 기록을 표시할 텍스트 컴포넌트
    public TMP_Text m_recordText;

    // 생존 시간
    private float _surviveTime;

    // 게임 오버 상태
    private bool _IsGameover;

    private void Start()
    {
        // 생존 시간과 게임 오버 상태 초기화
        _surviveTime = 0;

        _IsGameover = false;
    }

    private void Update()
    {
        // 게임 오버가 아닌 동안
        if(!_IsGameover)
        {
            // 생존 시간 갱신
            _surviveTime += Time.deltaTime;

            // 갱신한 생존 시간을 m_timeText 텍스트 컴포넌트를 이용해 표시
            m_timeText.text = "Time : " + (int) _surviveTime;
        }
        // 게임 오버라면
        else 
        {
            // R 키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    /// <summary>
    /// 현재 게임을 게임오버 상태로 변경하는 메서드
    /// </summary>
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        _IsGameover = true;

        // 게임오버 텍스트 게임 오브젝트를 활성화
        m_gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if(_surviveTime > bestTime) 
        {
            // 최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = _surviveTime;

            // 변경된 최고 기록 값을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 m_recordText 텍스트 컴포넌트를 이용해 표기
        m_recordText.text = "Best Time : " + (int)bestTime; 
    }
}
