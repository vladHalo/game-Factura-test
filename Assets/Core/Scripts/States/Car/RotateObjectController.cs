using UnityEngine;

namespace Core.Scripts.States.Car
{
    public class RotateObjectController : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private Transform _rotateObject;
        [SerializeField] private float _PCRotationSpeed = 10f;
        [SerializeField] private float _mobileRotationSpeed = 0.4f;

        private Vector3 _startRotation;

        private void Start()
        {
            _startRotation = _rotateObject.eulerAngles;
        }

        public void MoveInPC()
        {
            if (!Input.GetMouseButton(0)) return;
            float rotX = Input.GetAxis("Mouse X") * _PCRotationSpeed;

            Vector3 right = Vector3.Cross(_cam.transform.up, _rotateObject.position - _cam.transform.position);
            Vector3 up = Vector3.Cross(_rotateObject.position - _cam.transform.position, right);
            _rotateObject.rotation = Quaternion.AngleAxis(rotX, up) * _rotateObject.rotation;
            _rotateObject.eulerAngles = new Vector3(_startRotation.x, _rotateObject.eulerAngles.y, _rotateObject.eulerAngles.z);
        }

        public void MoveInMobile()
        {
            foreach (Touch touch in Input.touches)
            {
                Debug.Log("Touching at: " + touch.position);
                Ray camRay = _cam.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(camRay, out raycastHit, 10))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Touch phase began at: " + touch.position);
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        Debug.Log("Touch phase Moved");
                        _rotateObject.Rotate(touch.deltaPosition.y * _mobileRotationSpeed,
                            -touch.deltaPosition.x * _mobileRotationSpeed, 0, Space.World);
                        _rotateObject.eulerAngles = new Vector3(_startRotation.x, _rotateObject.eulerAngles.y, _rotateObject.eulerAngles.z);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        Debug.Log("Touch phase Ended");
                    }
                }
            }
        }
    }
}