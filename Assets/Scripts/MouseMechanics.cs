using UnityEngine;

public class MouseMechanics : MonoBehaviour {

	private Vector2 cursorPosition;
	private Ray ray;
	private RaycastHit2D rayHit;
	private GameObject selectedObject;
	private Vector2 originalPos;
	private int moveMode = 0;

	void Start() {

		selectedObject = null; // init for safety purposes

	}

	void Update() {
		
		// fire a ray from mouse (based on camera)
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// a simple vector2 conversion for cursor position
		cursorPosition = new Vector2(ray.origin.x, ray.origin.y);

		// when mouse is clicked
		if (Input.GetMouseButtonDown(0)) {
			// if there's already a selected object on cursor
			if (selectedObject == null) {

				// fire ray
				rayHit = Physics2D.Raycast(cursorPosition, ray.direction);

				// select object depending on the mode
				if (rayHit.collider.tag.Equals("Seed")) {
					// switch to object moving mode
					if (moveMode != 1) {
						selectedObject = rayHit.collider.gameObject;
						Debug.Log("Selected " + selectedObject.GetComponent<Seed>().seedName);
						originalPos = selectedObject.transform.position;
						moveMode = 1;
					}
				}
				else if (rayHit.collider.tag.Equals("WaterPot")) {
					// switch to object moving mode
					if (moveMode != 1) {
						selectedObject = rayHit.collider.gameObject;
						Debug.Log("Selected " + selectedObject.tag + ".");
						originalPos = selectedObject.transform.position;
						moveMode = 1;
					}
				}

			}
			// when clicked with an object on the cursor
			else {
				// run necessary processes...

				// reset selected object
				moveMode = 2;
				Debug.Log("Deselected object.");
			}

		}

		// carry object with cursor
		switch (moveMode) {
			case 0:
				break;
			case 1:
				selectedObject.transform.position = cursorPosition;
				break;
			case 2:
				selectedObject.transform.position = originalPos;
				selectedObject = null;
				originalPos = Vector2.zero;
				moveMode = 0;
				break;
		}

	}

}

