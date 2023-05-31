using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        [Header("Player Movement")] 
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private float m_rotationSpeed;
        [SerializeField] private float m_dashRange;
        [SerializeField] private float m_smoothAnim;

        [Header("Player Attacks")] 
        [SerializeField] private float m_attackDamage;
        [SerializeField] private float m_attackSpeed;
        [SerializeField] private float m_maxForce;
        
        private Vector3 m_rotationTarget;
        private Vector2 m_move;
        private Vector2 m_look;

        private Rigidbody m_rb;
        private Camera m_mainCam;
        private Animator m_animator;

        #endregion

        private void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            m_animator = GetComponent<Animator>();
            m_mainCam = Camera.main;
        }

        private void Update()
        {
            AnimationSmoothing();
        }

        private void FixedUpdate()
        {
            Move();
            Look();
        }

        #region CallbackFunctions

        public void OnMove(InputAction.CallbackContext _context)
        {
            m_move = _context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext _context)
        {
            m_look = _context.ReadValue<Vector2>();
        }

        public void OnDash(InputAction.CallbackContext _context)
        {
            if (_context.performed) Dash();
        }

        public void OnAttack(InputAction.CallbackContext _context)
        {
            if (_context.performed) Attack();
        }

        public void OnAbilityOne(InputAction.CallbackContext _context)
        {
            if (_context.started) AbilityOne();
        }

        public void OnAbilityTwo(InputAction.CallbackContext _context)
        {
            if (_context.started) AbilityTwo();
        }

        public void OnAbilityThree(InputAction.CallbackContext _context)
        {
            if (_context.started) AbilityThree();
        }

        public void OnUltimate(InputAction.CallbackContext _context)
        {
            if (_context.started) UltimateAbility();
        }

        #endregion

        #region MovementFunctions

        private void Look()
        {
            Ray mouseRay = m_mainCam.ScreenPointToRay(m_look);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            float rayDistance;
            if (!groundPlane.Raycast(mouseRay, out rayDistance)) return;
            Vector3 targetPosition = mouseRay.GetPoint(rayDistance);

            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
        }

        private void Move()
        {
            Vector3 movement = new Vector3(m_move.x, 0f, m_move.y) * m_movementSpeed * Time.fixedDeltaTime;
            m_rb.MovePosition(m_rb.position + movement);
        }

        private void Dash()
        {
            Debug.Log("Dashed");
        }

        #endregion

        #region AttackFunctions

        private void Attack()
        {
            Debug.Log("Attack!");
        }

        private void AbilityOne()
        {
            Debug.Log("A1");
        }

        private void AbilityTwo()
        {
            Debug.Log("A2");
        }

        private void AbilityThree()
        {
            Debug.Log("A3");
        }

        private void UltimateAbility()
        {
            Debug.Log("Ultimate");
        }

        #endregion

        #region AnimationFunctions

        private void AnimationSmoothing()
        {
                        
            float smoothedVertical = Mathf.SmoothStep(m_animator.GetFloat("Vertical"), m_move.y, m_smoothAnim * Time.deltaTime);
            m_animator.SetFloat("Vertical", smoothedVertical);
            
            float smoothedHorizontal = Mathf.SmoothStep(m_animator.GetFloat("Horizontal"), m_move.x, m_smoothAnim * Time.deltaTime);
            m_animator.SetFloat("Horizontal", smoothedHorizontal);
          
        }

        #endregion

        #region Debug

        private void DebugLogs()
        {
        
        }

        private void OnDrawGizmos()
        {
        }

        #endregion
    }
}