using System;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class CameraManager : MonoBehaviour
    {
        [Header("Camera Positioning")]
        public Vector2 CameraOffset = new Vector2(10f, 14f);
        public float LookAtOffset = 2f;

        [Header("Move Controls")]
        public float InOutSpeed = 5f;
        public float LateralSpeed = 5f;
        public float RotateSpeed = 40f;

        [Header("Move Bounds")]
        public Vector2 MinBounds;
        public Vector2 MaxBounds;

        [Header("Zoom Controls")]
        public float ZoomSpeed = 4f;
        public float NearZoomLimit = 2f;
        public float FarZoomLimit = 16f;
        public float StartingZoomLevel = 5f;

        private IZoomStrategy zoomStrategy;
        private Vector3 frameMove;
        private float frameRotate;
        private float frameZoom;
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = GetComponentInChildren<Camera>();

            mainCamera.transform.localPosition = new Vector3(0f, Mathf.Abs(CameraOffset.y), -Mathf.Abs(CameraOffset.x));
            zoomStrategy = mainCamera.orthographic ?
                new OrthographicZoom(mainCamera, StartingZoomLevel) :
                new PerspectiveZoom(mainCamera, CameraOffset, StartingZoomLevel) as IZoomStrategy;
            mainCamera.transform.LookAt(transform.position + Vector3.up * LookAtOffset);
        }

        private void OnEnable()
        {
            KeyboardInputManager.OnMoveInput += UpdateFrameMove;
            KeyboardInputManager.OnRotateInput += UpdateFrameRotation;
            KeyboardInputManager.OnZoomInput += UpdateFrameZoom;

            MouseInputManager.OnMoveInput += UpdateFrameMove;
            MouseInputManager.OnRotateInput += UpdateFrameRotation;
            MouseInputManager.OnZoomInput += UpdateFrameZoom;
        }


        private void OnDisable()
        {
            KeyboardInputManager.OnMoveInput -= UpdateFrameMove;
            KeyboardInputManager.OnRotateInput -= UpdateFrameRotation;
            KeyboardInputManager.OnZoomInput -= UpdateFrameZoom;

            MouseInputManager.OnMoveInput -= UpdateFrameMove;
            MouseInputManager.OnRotateInput -= UpdateFrameRotation;
            MouseInputManager.OnZoomInput -= UpdateFrameZoom;
        }

        private void UpdateFrameMove(Vector3 moveVector)
        {
            frameMove += moveVector;
        }

        private void UpdateFrameRotation(float rotateAmount)
        {
            frameRotate += rotateAmount;
        }

        private void UpdateFrameZoom(float zoomAmount)
        {
            frameZoom += zoomAmount;
        }

        private void LateUpdate()
        {
            if(frameMove != Vector3.zero)
            {
                var speedModFrameMove = new Vector3(frameMove.x * LateralSpeed, frameMove.y, frameMove.z * InOutSpeed);
                transform.position += transform.TransformDirection(speedModFrameMove) * Time.deltaTime;
                LockPositionInBoinds();
                frameMove = Vector3.zero;
            }

            if(frameRotate != 0f)
            {
                transform.Rotate(Vector3.up, frameRotate * RotateSpeed * Time.deltaTime);
                frameRotate = 0;
            }

            if(frameZoom < 0)
            {
                zoomStrategy.ZoomIn(mainCamera, Mathf.Abs(frameZoom) * ZoomSpeed * Time.deltaTime, NearZoomLimit);
                frameZoom = 0;
            }
            else if(frameZoom > 0)
            {
                zoomStrategy.ZoomOut(mainCamera, frameZoom * ZoomSpeed * Time.deltaTime, FarZoomLimit);
                frameZoom = 0;
            }
        }

        private void LockPositionInBoinds()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, MinBounds.x, MaxBounds.x),
                transform.position.y,
                Mathf.Clamp(transform.position.z, MinBounds.y, MaxBounds.y));
                
        }

        private void OnDrawGizmos()
        {
            
        }
    }
}