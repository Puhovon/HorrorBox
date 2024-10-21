using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _aboutButton;
        [SerializeField] private Button _closeAboutButton;
        [SerializeField] private Button _exitButton;

        [Header("Panels")]
        [SerializeField] private GameObject _aboutPanel;
        
        private const int LevelIndex = 1;
        
        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _aboutButton.onClick.AddListener(OpenAbout);
            _closeAboutButton.onClick.AddListener(CloseAbout);
            _exitButton.onClick.AddListener(CloseGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _aboutButton.onClick.RemoveListener(OpenAbout);
            _closeAboutButton.onClick.RemoveListener(CloseAbout);
            _exitButton.onClick.RemoveListener(CloseGame);
        }
        
        private void CloseGame()
        {
            Application.Quit();
        }

        private void OpenAbout()
        {
            _aboutPanel.SetActive(true);
        }
        
        private void CloseAbout()
        {
            _aboutPanel.SetActive(false);
        }
        
        private void StartGame()
        {
            SceneManager.LoadScene(LevelIndex);
        }
    }
}