using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class InputManager : MonoBehaviour
    {
        public delegate void MoveInputHandler(Vector3 moveVector);
        public delegate void RotateInputHandler(float rotateAmount);
        public delegate void ZoomInputHandler(float zoomAmount);

        protected abstract void HandleMovement();
        protected abstract void HandleRotation();
        protected abstract void HandleZoom();

        protected virtual void Update()
        {
            HandleMovement();
            HandleRotation();
            HandleZoom();
        }
    }
}