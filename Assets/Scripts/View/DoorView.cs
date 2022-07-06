using UnityEngine;

namespace EcsLiteTest.View
{
    public class DoorView : MonoBehaviour
    {
        public float openSpeed = 1f;
        public Transform plate;
        public Transform pivot;
        public DoorButtonView button;

        public float Width { get; private set; }

        public float OpenProgress
        {
            set => pivot.localPosition = Vector3.Lerp(Vector3.zero, Vector3.left * Width, value);
        }

        private void Awake()
        {
            Width = plate.GetComponent<Renderer>().localBounds.size.x * plate.lossyScale.x;
        }
    }
}