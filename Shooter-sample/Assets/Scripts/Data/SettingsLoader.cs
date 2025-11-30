using UnityEngine;

namespace Data
{
    public class SettingsLoader : MonoBehaviour
    {
        public static SettingsLoader Instance { get; private set; }

        private GameSettings _settings = new GameSettings();
        public GameSettings Settings => _settings;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadSettings();
        }

        public void LoadSettings()
        {
            //...
        }

        public void SaveSettings()
        {
            //...
        }
    }
}