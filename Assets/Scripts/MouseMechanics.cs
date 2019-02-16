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
        Vector3 clickPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BTN))
        {
            Debug.Log("Mouse clicked .... ");
            // get mouse click position in world unit(not in actual pixel unit)
            Collider2D collider2D = Physics2D.OverlapPoint(new Vector2(clickPos.x, clickPos.y));
            if (collider2D != null && collider2D.CompareTag("TagSeedEggPlant"))
            {
                Debug.Log("Clicked on the Eggplant seeds...");
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

