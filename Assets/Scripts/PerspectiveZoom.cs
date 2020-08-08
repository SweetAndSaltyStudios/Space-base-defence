using UnityEngine;
 namespace Sweet_And_Salty_Studios
{
    public class PerspectiveZoom : IZoomStrategy
    {
        private Vector3 normalizedCameraPosition;
        private float currentZoomLevel;

        public PerspectiveZoom(Camera camera, Vector3 offset, float startingZoomLevel)
        {
            // ofsetX...
            normalizedCameraPosition = new Vector3(0f, Mathf.Abs(offset.y), -Mathf.Abs(offset.x)).normalized;
            currentZoomLevel = startingZoomLevel;
            PositionCamera(camera);
        }

        private void PositionCamera(Camera camera)
        {
            camera.transform.localPosition = normalizedCameraPosition * currentZoomLevel;
        }

        public void ZoomIn(Camera camera, float delta, float nearZoomLimit)
        {
            if(currentZoomLevel <= nearZoomLimit)
            {
                return;
            }

           currentZoomLevel = Mathf.Max(currentZoomLevel - delta, nearZoomLimit);

            PositionCamera(camera);
        }

        public void ZoomOut(Camera camera, float delta, float farZoomLimit)
        {
            if(currentZoomLevel >= farZoomLimit)
            {
                return;
            }

            currentZoomLevel = Mathf.Min(currentZoomLevel + delta, farZoomLimit);

            PositionCamera(camera);
        }
    }
}
