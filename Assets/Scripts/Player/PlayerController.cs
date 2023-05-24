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
        [SerializeField] private float m_dashRange;

        [Header("Player Attacks")] 
        [SerializeField] private float m_attackDamage;
        [SerializeField] private float m_attackSpeed;
        [SerializeField] private float m_rotationSpeed;
        [SerializeField] private float m_maxForce;
        
        private Vector3 m_rotationTarget;
        private Vector2 m_move;
        private Vector2 m_look;

        private Rigidbody m_rb;
        
        #endregion

        private void Start()
        {
            m_rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
 
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
            if(_context.performed) Dash();
        }

        public void OnAttack(InputAction.CallbackContext _context)
        {
            if(_context.performed) Attack();
        }

        public void OnAbilityOne(InputAction.CallbackContext _context)
        {
            if(_context.started) AbilityOne();
        }
        
        public void OnAbilityTwo(InputAction.CallbackContext _context)
        {
            if(_context.started) AbilityTwo();
        }
        
        public void OnAbilityThree(InputAction.CallbackContext _context)
        {
            if(_context.started) AbilityThree();
        }

        public void OnUltimate(InputAction.CallbackContext _context)
        {
            if(_context.started) UltimateAbility();
        }
        
        #endregion

        #region MovementFunctions

        private void Look()
        {
            Quaternion rotation = Quaternion.Euler(Vector3.up * m_move.x * m_rotationSpeed * Time.fixedDeltaTime);
            m_rb.MoveRotation(m_rb.rotation * rotation);
        }

        private void Move()
        {
            Vector3 movement = new Vector3(m_move.x, 0f, m_move.y) * m_movementSpeed * Time.deltaTime;
            m_rb.MovePosition(m_rb.position + transform.TransformDirection(movement));
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
        
        #region Debug

        private void DebugLogs()
        {
            Debug.Log(m_move);
        }
        
        private void OnDrawGizmos()
        {
           
        }

        #endregion
    }
}
