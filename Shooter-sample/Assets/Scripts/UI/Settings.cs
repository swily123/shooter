using UnityEngine;

namespace UI
{
    public class Settings : MonoBehaviour
    {
        
        
        private bool _isActive;

        private void Awake()
        {
            _isActive = false;
        }

        public void ToggleListening()
        {
            _isActive = !_isActive;
        }
        
        private void OnGUI()
        {
            if (_isActive == false)
                return;
            
            Event e = Event.current;
            
            if (e == null)
                return;
            
            if (e.isKey && e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.Backspace)
                {
                    _isActive = false;
                    return;
                }

                _isActive = false;
                Debug.Log(e.keyCode);
                e.Use();
            }
            else if (e.isMouse && e.type == EventType.MouseDown)
            {
                if (e.keyCode == KeyCode.Backspace)
                {
                    _isActive = false;
                    return;
                }
                
                _isActive = false;
                Debug.Log("mouse code -" + e.button);
                e.Use();
            }
        }
    }
}