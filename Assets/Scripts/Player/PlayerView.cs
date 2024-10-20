using UnityEngine;

namespace Player.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private AudioSource _walkSource;
        [SerializeField] private AudioClip _walkSound;
        [SerializeField] private float _stepInterval = 0.4f;
        private float _stepTimer = 0;
        private bool _isWalking;

        private void Update()
        {
            _stepTimer += Time.deltaTime;
            if(!_isWalking)
                return;
            if (_stepTimer >= _stepInterval )
            {
                if(!_walkSource.isPlaying)
                    _walkSource.PlayOneShot(_walkSound);
                _stepTimer = 0;
            }
        }

        public void StartWalk()
        {
            _isWalking = true;
        }

        public void StopWalk()
        {
            _isWalking = false;
        }
    }
}