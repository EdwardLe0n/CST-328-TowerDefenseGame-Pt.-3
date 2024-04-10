using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        // If a player presses escape, the map won't move
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        // If doMovement == false, then it will ignore the camera movement code
        if (!doMovement)
        {
            return;
        }

        // Cam Movement code
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {

            transform.Translate(Vector3.forward * panSpeed * -1f * Time.deltaTime, Space.World);

        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {

            transform.Translate(Vector3.right * panSpeed * -1f * Time.deltaTime, Space.World);

        }

        // Scroll view code
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 *  scrollSpeed * Time.deltaTime;

        // Clamps the y var between the preset min and max y float vals
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
