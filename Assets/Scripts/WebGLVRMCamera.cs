using UnityEngine;

public class WebGLVRMCamera : MonoBehaviour
{
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float moveSpeed;
    private float min = 0.01f;

    private float x;
    private float y;

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        this.transform.localScale = this.transform.localScale - new Vector3(zoomSpeed, zoomSpeed, zoomSpeed) * scroll;
        if (this.transform.localScale.x < min)
        {
            this.transform.localScale = new Vector3(min, min, min);
        }

        if (Input.GetMouseButton(0))
        {
            y += mouseY * moveSpeed;
            x += mouseX * moveSpeed;
        }
        this.transform.rotation = Quaternion.Euler(new Vector3(y, x, 0.0f));
    }
}
