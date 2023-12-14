using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float m_rotationSpeed = 60f;

    private void Update()
    {
        transform.Rotate(0, m_rotationSpeed*Time.deltaTime,0);
    }
}
