using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class KeyboardInputManager : InputManager
    {
        public static event MoveInputHandler OnMoveInput;
        public static event RotateInputHandler OnRotateInput;
        public static event ZoomInputHandler OnZoomInput;

        protected override void HandleMovement()
        {
            if(Input.GetKey(KeyCode.W))
            {
                OnMoveInput?.Invoke(Vector3.forward);
            }

            if(Input.GetKey(KeyCode.S))
            {
                OnMoveInput?.Invoke(Vector3.back);
            }

            if(Input.GetKey(KeyCode.A))
            {
                OnMoveInput?.Invoke(Vector3.left);
            }

            if(Input.GetKey(KeyCode.D))
            {
                OnMoveInput?.Invoke(Vector3.right);
            }
        }

        protected override void HandleRotation()
        {
            if(Input.GetKey(KeyCode.E))
            {
                OnRotateInput?.Invoke(-1f);
            }

            if(Input.GetKey(KeyCode.Q))
            {
                OnRotateInput?.Invoke(1f);
            }
        }

        protected override void HandleZoom()
        {
            if(Input.GetKey(KeyCode.Z))
            {
                OnZoomInput?.Invoke(-1f);
            }

            if(Input.GetKey(KeyCode.C))
            {
                OnZoomInput?.Invoke(1f);
            }
        }      
    }
}