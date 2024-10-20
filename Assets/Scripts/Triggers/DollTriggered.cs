using System.Collections;
using Player.Lighter;
using UnityEngine;

namespace Player.Triggers
{
    public class DollTriggered : MonoBehaviour
    {
        [SerializeField] private GameObject _boxVolume;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Collider _collider;
        [SerializeField] private LightFlicker _flicker;

        private bool _isPlayed;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            if (_isPlayed)
                return;
            _isPlayed = true;
            _flicker.Triggered();
            StartCoroutine(Agressive());
        }

        private IEnumerator Agressive()
        {
            _renderer.enabled = false;
            _boxVolume.SetActive(true);
            _collider.enabled = false;
            yield return new WaitForSeconds(30);
            _boxVolume.SetActive(false);
            _renderer.enabled = true;
            _collider.enabled = true;

        }
    }
}