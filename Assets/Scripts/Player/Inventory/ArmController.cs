using System;
using Items.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class ArmController : MonoBehaviour
    {
        [SerializeField] private Transform _itemPoint;
        private IItem _currentItem;
        private IInteractableItem _usableItem;
        private PlayerInput _input;
        private ArmControllerConfig _config;
        private Inventory _inventory;
        
        [SerializeField]private bool _isUsableItemInArm;

        [Inject]
        private void Construct(PlayerInput input, ArmControllerConfig config, Inventory inventory)
        {
            _input = input;
            _config = config;
            _inventory = inventory;
        }

        private void OnEnable()
        {
            if (_currentItem != null && _usableItem != null)
                _input.Player.Use.performed += UseItem;
            else
                _input.Player.Use.performed += GetItem;
        }
        
        private void OnDisable()
        {
            if (_currentItem != null)
                _input.Player.Use.performed -= UseItem;
            else
                _input.Player.Use.performed -= GetItem;
        }
        
        private void GetItem(InputAction.CallbackContext obj)
        {
            RaycastHit hit;

            if (!Physics.Raycast(transform.position, transform.forward, out hit, _config.Distance))
                return;
            if (!hit.transform.TryGetComponent(out IItem armItem))
                return;
            if (hit.transform.TryGetComponent(out IInteractableItem item))
                _usableItem = item;
            TakeItem(armItem);
        }

        private void TakeItem(IItem item)
        {
            if(!_inventory.CanPullItem())
                return;
            _input.Player.Use.performed -= GetItem;
            _inventory.PullItem(item);
            _currentItem = item;
            SetItemTransform();
            _input.Player.Interaction.performed += UseItem;
        }

        private void SetItemTransform()
        {
            _currentItem.Transform.parent = _itemPoint;
            _currentItem.Take();

        }

        private void UseItem(InputAction.CallbackContext obj)
        {
            if (_usableItem == null)
                throw new ArgumentNullException("Man, this item is not usable...");
            _usableItem.Use();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, transform.forward * _config.Distance);
        }
    }
}