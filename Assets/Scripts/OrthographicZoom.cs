using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class OrthographicZoom : IZoomStrategy
    {
        public OrthographicZoom(Camera camera, float startingZoomLevel)
        {
            camera.orthographicSize = startingZoomLevel;
        }

        public void ZoomIn(Camera camera, float delta, float nearZoomLimit)
        {
            if(camera.orthographicSize == nearZoomLimit)
            {
                return;
            }

            camera.orthographicSize = Mathf.Max(camera.orthographicSize - delta, nearZoomLimit);
        }

        public void ZoomOut(Camera camera, float delta, float farZoomLimit)
        {
            if(camera.orthographicSize == farZoomLimit)
            {
                return;
            }

            camera.orthographicSize = Mathf.Min(camera.orthographicSize + delta, farZoomLimit);
        }
    }
}