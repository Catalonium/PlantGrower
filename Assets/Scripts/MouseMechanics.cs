using UnityEngine;

public class MouseMechanics : MonoBehaviour {

    // Main Camera
    public Camera mainCam;

    // Constant values for primary mouse button
    private const int PRIMARY_MOUSE_BTN = 0;

    // variable to hold clicked object 

    void Start()
    {
        // init mouse position assignment
    }

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Vector2 origin = new Vector2(ray.origin.x, ray.origin.y);

        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BTN))
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, ray.direction);

            Debug.Log("coordinate : " + ray.origin.x + " " + ray.origin.y + " ");
            if (raycastHit2D.collider != null) {
                Debug.Log("Hit something");
            }
            else
            {
                Debug.Log("Didn't hit anything.");
            }
        }
    }

    void FixedUpdate()
    {
        // update mouse position

        // select clicked object and carry it with cursor

        // when clicked with an object on the cursor, reset it
    }

}

