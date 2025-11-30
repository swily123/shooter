using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _crosshair;
    
    private bool _isOnPause;
    
    private void OnEnable()
    {
        _inputReader.Pausing += OnPause;
    }

    private void OnDisable()
    {
        _inputReader.Pausing -= OnPause;
    }

    private void Start()
    {
        Resume();
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        _menu.SetActive(false);
        _crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        _inputReader.UnlockInput();
        _isOnPause = false;
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }
    
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    private void OnPause()
    {
        if (_isOnPause)
            Resume();
        else
        {
            _isOnPause = true;
            _inputReader.BlockInput();
            Cursor.lockState = CursorLockMode.None;
            _menu.SetActive(true);
            _crosshair.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}