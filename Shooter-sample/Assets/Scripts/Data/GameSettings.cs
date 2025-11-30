using UnityEngine;

namespace Data
{
    public class GameSettings
    {   
        public float mouseSensitivityX = 1f;
        public float mouseSensitivityY = 1f;
        public bool invertY = false;
        
        public KeyCode moveForward = KeyCode.W; 
        public KeyCode moveBackward = KeyCode.S;
        public KeyCode moveLeft = KeyCode.A;
        public KeyCode moveRight = KeyCode.D;
        public KeyCode jump = KeyCode.Space;
        public KeyCode attack = KeyCode.Mouse0;
        public KeyCode pause = KeyCode.Escape;
    }
}