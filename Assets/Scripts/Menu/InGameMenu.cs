using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Player.Menu
{
    public class InGameMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _backButton;
        [Space] [SerializeField] private GameObject _menuPanel;

        private const int MainMenuIndex = 0;
        private PlayerInput _input;
        private bool _isPaused;
        
        [Inject]
        private void Construct(PlayerInput input) => _input = input;
        
        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
            _backButton.onClick.AddListener(CloseMenu);
            _input.Player.Esc.performed += Pause;
        }

        private void Pause(InputAction.CallbackContext obj)
        {
            if (!_isPaused)
            {
                _isPaused = true;
                _menuPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
            }
            else
            {
                _isPaused = false;
                _menuPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
            _backButton.onClick.RemoveListener(CloseMenu);
            _input.Player.Esc.performed -= Pause;
        }
        private void CloseMenu()
        {
            print("AAAAAAAAAAAAAA");
            _menuPanel.SetActive(false);
            _isPaused = false;
            Time.timeScale = 1;
        }

        private void GoToMainMenu()
        {
            print("AAAAAAAAAAAAAA");
            SceneManager.LoadScene(MainMenuIndex);
        }
    }
}