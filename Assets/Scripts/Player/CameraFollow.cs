using System;
using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform m_playerTransform;
        [SerializeField] private Transform m_cameraHolder;
        [SerializeField] private float m_smoothSpeed;

        private void LateUpdate()
        {
            Vector3 target = m_playerTransform.position + m_cameraHolder.position;
            Vector3 smoothTarget = Vector3.Lerp(transform.position, target, m_smoothSpeed * Time.deltaTime);
            transform.position = smoothTarget;
        }
    }
}
