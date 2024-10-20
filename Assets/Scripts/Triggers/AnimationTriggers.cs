using System;
using UnityEngine;

namespace Player.Triggers
{
    public class AnimationTriggers : MonoBehaviour
    {
        private bool _isPlayed;
        [SerializeField] private Animation _animation;

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
                return;
            if(_isPlayed)
                return;
            _animation.Play();
            _isPlayed = true;
        }
    }
}