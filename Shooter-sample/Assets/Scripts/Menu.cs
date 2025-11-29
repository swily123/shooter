using Character;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private PlayerCameraMover  _playerCameraMover;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _crosshair;

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
        _playerCameraMover.ResumeMoving();
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
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            _menu.SetActive(true);
            _crosshair.SetActive(false);
            _playerCameraMover.StopMoving();
            Time.timeScale = 0f;
        }
    }
}