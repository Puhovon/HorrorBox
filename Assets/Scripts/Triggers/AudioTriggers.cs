using UnityEngine;

namespace Player.Triggers
{
    public class AudioTriggers : MonoBehaviour
    {
        private bool _isPlayed;
        [SerializeField] private AudioSource _source;
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
                return;
            if (_isPlayed)
                return;
            _source.Play();
            _isPlayed = true;
        }
    }
}