using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public interface IZoomStrategy
    {
        void ZoomIn(Camera camera, float delta, float nearZoomLimit);
        void ZoomOut(Camera camera, float delta, float farZoomLimit);
    }
}