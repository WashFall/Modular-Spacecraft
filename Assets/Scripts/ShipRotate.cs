using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    public float sensitivity = 1f;

    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.down, XaxisRotation);
    }

}
