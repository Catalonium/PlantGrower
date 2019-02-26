using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMechanics : MonoBehaviour {

    // for object pooling
    private List<GameObject> cropPool;

    public GameObject eggplantCrop;
    public GameObject pumpkinCrop;
    public GameObject cucumberCrop;

    public GameObject playground;
    public GameObject seed;

    public Sprite spriteEggplantCrop;
    public Sprite spriteCucumberCrop;
    public Sprite spritePumpkinCrop;

    private Vector2 cursorPosition;
    private Ray ray;
    private RaycastHit2D rayHit;
    private GameObject selectedObject;
    private Vector2 originalPos;
    private int moveMode = 0;

    private const string TAG_SEED = "Seed";
    private const string TAG_WATERPOT = "WaterPot";
    private const string TAG_FIELD = "Field";

    void Start() {
        SetupPool();
        selectedObject = null; // init for safety purposes
    }

    void Update() {

        // fire a ray from mouse (based on camera)
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // a simple vector2 conversion for cursor position
        cursorPosition = new Vector2(ray.origin.x, ray.origin.y);

        // when mouse is clicked
        if (Input.GetMouseButtonDown(0)) {
            // fire ray
            rayHit = Physics2D.Raycast(cursorPosition, ray.direction);
            // if there's already a selected object on cursor
            if (rayHit.collider != null) {
                // tag of the collider
                string collidedTag = rayHit.collider.tag;
                if (selectedObject == null) {
                    // select object depending on the mode
                    switch (collidedTag) {
                        case TAG_SEED:
                            // switch to object moving mode
                            if (moveMode != 1) {
                                selectedObject = rayHit.collider.gameObject;
                                Debug.Log("Selected " + selectedObject.GetComponent<Seed>().seedName + " seed");
                                originalPos = selectedObject.transform.position;
                                alphaChanger(selectedObject);
                                moveMode = 1;
                            }
                            break;
                        case TAG_WATERPOT:
                            // switch to object moving mode
                            if (moveMode != 1) {
                                selectedObject = rayHit.collider.gameObject;
                                Debug.Log("Selected " + selectedObject.tag);
                                originalPos = selectedObject.transform.position;
                                moveMode = 1;
                            }
                            break;
                    }
                }
                // when clicked with an object on the cursor
                else {
                    var hitCollider = rayHit.collider;
                    // put seed on the field
                    if (hitCollider.tag.Equals(TAG_FIELD)) {
                        GameObject fieldObj = hitCollider.gameObject;
                        Field fieldScript = fieldObj.GetComponent<Field>();
                        switch (selectedObject.tag) {
                            case "WaterPot":
                                // start growing timer when pour water to plant
                                fieldScript.PourWater();
                                break;
                            default:
                                // Grow a new seed on the selected(clicked) field.
                                string selectedSeedName = selectedObject.GetComponent<Seed>().seedName;
                                GameObject obj = GetPooledObject(selectedSeedName);
                                if (obj != null) {
                                    fieldScript.currentlyHoldingObj = obj;
                                    Vector3 fieldPos = fieldObj.transform.position;
                                    obj.transform.position = fieldPos;
                                    obj.SetActive(true);
                                }
                                break;
                        }
                    }

                    // reset selected object
                    moveMode = 2;
                    if (selectedObject.tag.Equals("Seed")) alphaChanger(selectedObject);
                    Debug.Log("Deselected object");
                }
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

    void alphaChanger(GameObject selectedObj) {
        var img = selectedObj.GetComponent<Image>();
        var clr = img.color;
        if (clr.a != 0) clr.a = 0;
        else clr.a = 1;
        img.color = clr;
    }

    /// <summary>
    ///     Setting up cache pool for game object spawning
    /// </summary>
    void SetupPool() {
        cropPool = new List<GameObject>();
        // 2-eggplant in the pool
        for (int i = 0; i < 4; i++) {
            GameObject obj = (GameObject)Instantiate(eggplantCrop, playground.transform);
            obj.GetComponent<Image>().sprite = spriteEggplantCrop;
            obj.SetActive(false);
            alphaChanger(obj);
            cropPool.Add(obj);
        }
        // 2-cucumber in the pool
        for (int i = 0; i < 2; i++) {
            GameObject obj = (GameObject)Instantiate(cucumberCrop, playground.transform);
            obj.GetComponent<Image>().sprite = spriteCucumberCrop;
            obj.SetActive(false);
            alphaChanger(obj);
            cropPool.Add(obj);
        }
        // 2-pumpkin in the pool
        for (int i = 0; i < 2; i++) {
            GameObject obj = (GameObject)Instantiate(pumpkinCrop, playground.transform);
            obj.GetComponent<Image>().sprite = spritePumpkinCrop;
            obj.SetActive(false);
            alphaChanger(obj);
            cropPool.Add(obj);
        }
    }

    /// <summary>
    ///     Get game object from cache depending on the crop name.
    /// </summary>
    /// <param name="crop">crop name to get.</param>
    /// <returns>GameObject or null</returns>
    GameObject GetPooledObject(string crop) {
        int cnt = cropPool.Count;// pool count
        for (int i = 0; i < cnt; i++) {
            string name = cropPool[i].GetComponent<Seed>().seedName;
            if (crop.Equals(name) && !cropPool[i].activeInHierarchy) {
                return cropPool[i];
            }
        }
        return null;
    }
}

