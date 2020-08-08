using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class MouseInputManager : InputManager
    {
        public static event MoveInputHandler OnMoveInput;
        public static event RotateInputHandler OnRotateInput;
        public static event ZoomInputHandler OnZoomInput;

        public float MouseScrollSensitivity = -3f;

        private Vector2Int screenSize = new Vector2Int(Screen.width, Screen.height);
        private Vector2 mousePosition;
        private float mousePositionOnRotateStart;

        protected override void Update()
        {
            mousePosition = Input.mousePosition;
            var mouseValid =  mousePosition.y <= screenSize.y * 1.05f &&
                              mousePosition.y >= screenSize.y * -0.05f &&
                              mousePosition.x <= screenSize.x * 1.05f &&
                              mousePosition.x >= screenSize.x * -0.05f;

            if(mouseValid == false)
            {
                return;
            }

            base.Update();
        }

        protected override void HandleMovement()
        {
            if(mousePosition.y > screenSize.y * 0.95f)
            {
                OnMoveInput?.Invoke(Vector3.forward);
            }
            else if(mousePosition.y < screenSize.y * 0.05f)
            {
                OnMoveInput?.Invoke(Vector3.back);
            }

            if(mousePosition.x > screenSize.x * 0.95f)
            {
                OnMoveInput?.Invoke(Vector3.right);
            }
            else if(mousePosition.x < screenSize.x * 0.05f)
            {
                OnMoveInput?.Invoke(Vector3.left);
            }
        }

        protected override void HandleRotation()
        {
            if(Input.GetMouseButtonDown(1))
            {
                mousePositionOnRotateStart = mousePosition.x;
            }
            else if(Input.GetMouseButton(1))
            {
                if(mousePosition.x < mousePositionOnRotateStart)
                {
                    OnRotateInput?.Invoke(-1f);
                }
                else if(mousePosition.x > mousePositionOnRotateStart)
                {
                    OnRotateInput?.Invoke(1f);
                }
            }
        }

        protected override void HandleZoom()
        {
            if(Input.mouseScrollDelta.y > 0)
            {
                OnZoomInput?.Invoke(MouseScrollSensitivity);
            }
            else if(Input.mouseScrollDelta.y < 0)
            {
                OnZoomInput?.Invoke(-MouseScrollSensitivity);
            }
        }
    }
}
