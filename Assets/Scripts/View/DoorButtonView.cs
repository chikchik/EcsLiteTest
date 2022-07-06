using System.Collections;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class DoorButtonView : MonoBehaviour
    {
        public Transform pivot;
        public Transform plate;

        private float pressSpeed = 1f;
        private float height;
        private bool pressed;
        private Coroutine pressCoroutine;

        public bool Pressed
        {
            set
            {
                if (pressed != value)
                {
                    pressed = value;

                    if (pressCoroutine != null)
                        StopCoroutine(pressCoroutine);

                    pressCoroutine = StartCoroutine(UpdatePress());
                }
            }
        }

        private void Awake()
        {
            height = plate.GetComponent<Renderer>().localBounds.size.y * plate.lossyScale.y;
        }

        private IEnumerator UpdatePress()
        {
            Vector3 target = pressed ? Vector3.down * (height - 0.005f) : Vector3.zero;

            while (pivot.localPosition != target)
            {
                pivot.localPosition = Vector3.MoveTowards(pivot.localPosition, target, pressSpeed * Time.deltaTime);

                yield return null;
            }

            pressCoroutine = null;
        }
    }
}