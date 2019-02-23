using System.Collections.Generic;
using UnityEngine;

public class MouseMechanics : MonoBehaviour {

    // for object pooling
    private List<GameObject> cropPool;

    public GameObject eggplantCrop;
    public GameObject pumpkinCrop;
    public GameObject cucumberCrop;

    public GameObject playground;
    public GameObject seed;

    private Vector2 cursorPosition;
    private Ray ray;
    private RaycastHit2D rayHit;
    private GameObject selectedObject;
    private Vector2 originalPos;
    private int moveMode = 0;

    private const string TAG_SEED = "Seed";
    private const string TAG_WATERPOT = "WaterPot";
    private const string TAG_FIELD = "Field";

    void Start()
    {
        SetupPool();
        selectedObject = null; // init for safety purposes
    }

    void Update()
    {

        // fire a ray from mouse (based on camera)
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // a simple vector2 conversion for cursor position
        cursorPosition = new Vector2(ray.origin.x, ray.origin.y);

        // when mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // fire ray
            rayHit = Physics2D.Raycast(cursorPosition, ray.direction);
            // if there's already a selected object on cursor
            if (rayHit.collider != null)
            {
                // tag of the collider
                string collidedTag = rayHit.collider.tag;
                if (selectedObject == null)
                {
                    // select object depending on the mode
                    switch (collidedTag)
                    {
                        case TAG_SEED:
                            // switch to object moving mode
                            if (moveMode != 1)
                            {
                                selectedObject = rayHit.collider.gameObject;
                                Debug.Log("Selected " + selectedObject.GetComponent<Seed>().seedName + " seed");
                                originalPos = selectedObject.transform.position;
                                moveMode = 1;
                            }
                            break;
                        case TAG_WATERPOT:
                            // switch to object moving mode
                            if (moveMode != 1)
                            {
                                selectedObject = rayHit.collider.gameObject;
                                Debug.Log("Selected " + selectedObject.tag);
                                originalPos = selectedObject.transform.position;
                                moveMode = 1;
                            }
                            break;
                    }
                }
                // when clicked with an object on the cursor
                else
                {
                    // run necessary processes...
                    if (rayHit.collider.tag.Equals(TAG_FIELD))
                    {
                        // initiate a new seed on the selected(clicked) field.
                        // ========== Need to fix here ==========
                        string selectedSeedName = selectedObject.GetComponent<Seed>().seedName;
                        GameObject obj = GetPooledObject(selectedSeedName);
                        if (obj != null)
                        {
                            switch (selectedSeedName)
                            {
                                case Seed.EGGPLANT_NAME:
                                    obj.transform.position = cursorPosition;
                                    obj.SetActive(true);
                                    break;
                                case Seed.PUMPKIN_NAME:
                                    Debug.Log("Pumpkin dropped");
                                    break;
                                case Seed.CUCUMBER_NAME:
                                    Debug.Log("Cucumber dropped");
                                    break;
                            }
                        }
                    }
                    // reset selected object
                    moveMode = 2;
                    Debug.Log("Deselected object");
                }
            }

        }

        // carry object with cursor
        switch (moveMode)
        {
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

    void SetupPool()
    {
        cropPool = new List<GameObject>();
        // 2-eggplant in the pool
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = (GameObject)Instantiate(eggplantCrop, playground.transform);
            obj.SetActive(false);
            cropPool.Add(obj);
        }
        // 2-cucumber in the pool
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = (GameObject)Instantiate(cucumberCrop, playground.transform);
            obj.SetActive(false);
            cropPool.Add(obj);
        }
        // 2-pumpkin in the pool
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = (GameObject)Instantiate(pumpkinCrop, playground.transform);
            obj.SetActive(false);
            cropPool.Add(obj);
        }
    }

    GameObject GetPooledObject(string crop)
    {
        int cnt = cropPool.Count;// pool count
        for(int i = 0; i < cnt; i++)
        {
            string name = cropPool[i].GetComponent<Seed>().seedName;
            if (crop.Equals(name) && !cropPool[i].activeInHierarchy)
            {
                return cropPool[i];
            }
        }
        return null;
    }

}

