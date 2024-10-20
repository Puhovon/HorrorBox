using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Lighter
{
    public class LightFlicker : MonoBehaviour
    {
        [SerializeField] private List<Light> _light;
        [SerializeField] private int _countOfFlick;

        public void Triggered()
        {
            StartCoroutine(Flicker());
        }
        
        private IEnumerator Flicker()
        {
            int currentCount = 0;
            while (currentCount <= _countOfFlick)
            {
                _light.ForEach(l => l.enabled = !l.enabled);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}