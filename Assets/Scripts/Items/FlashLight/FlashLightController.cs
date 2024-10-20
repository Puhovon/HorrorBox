using System.Collections.Generic;
using Items.Abstract;
using UnityEngine;

namespace Items.FlashLight
{
    public class FlashLightController : MonoBehaviour, IInteractableItem
    {
        public Transform Transform => transform;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Collider _collider;
        [SerializeField]private List<Light> _light;
        private bool _isTurningOff;
        
        public void Take()
        {
            _rb.isKinematic = true;
            _collider.isTrigger = true;
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0,0,0,0);
            
        }

        public void Drop()
        {
            _rb.isKinematic = false;
            _collider.isTrigger = false;
        }

        public void Use()
        {
            if (_isTurningOff)
                _light.ForEach(l => l.enabled = true);
            else
                _light.ForEach(l => l.enabled = false);
            _isTurningOff = !_isTurningOff;
        }
    }
}