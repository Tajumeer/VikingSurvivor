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
        
        private Vector2 m_move;
        private Vector2 m_look;

        #endregion

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
            
        }

        private void Move()
        {
            
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

        private void OnDrawGizmos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
