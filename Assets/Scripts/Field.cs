using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour {

    public Seed pickedCrop;
    // To check whether the pour water on this field or not
    public bool isWatered;
    // To check whether the crop exist on this field or not
    public bool hasCrop;
    // Number of seconds to change crop
    public float sec;
    // currently holding crop on this field
    public GameObject currentlyHoldingObj;
    // sprite for eggplant crop
    public Sprite eggplantSprite;
    // sprite for pumpkin crop
    public Sprite pumpkinSprite;
    // sprite for cucumber crop
    public Sprite cucumberSprite;
    // sprite for seed
    public Sprite seedSprite;
    // TODO comment
    public int timer;
    // crop change from plant to vegetable time constant
    private const int CROP_TIMER = 5;

    void Start() {
        // set timer and stuff (for individual crop field)
        isWatered = false;
        timer = 0;
    }

    void Update() {
        // TODO this is where crops should be held (from placed seeds)
        // so that seeds will "turn" into crops, and will "grow" here

        // if clicked with a crop, assign it to currentCrop
        // assign growTime to timer

        // if clicked with pot, isWatered true
        // start timer count down

        // if timer ends, reset the field and add grown plant's score to background scores

        if (isWatered) {
            GrowOnWater();
        }
    }

    void GrowOnWater() {
        sec += Time.deltaTime;
        if (sec >= CROP_TIMER && currentlyHoldingObj != null) { // null control is to prevent an occasional error, further testing beneficial
            sec = 0;
            isWatered = false;
            string seedName = currentlyHoldingObj.GetComponent<Seed>().seedName;
            switch (seedName) {
                case Seed.EGGPLANT_NAME:
                    currentlyHoldingObj.GetComponent<Image>().sprite = eggplantSprite;
                    break;
                case Seed.PUMPKIN_NAME:
                    currentlyHoldingObj.GetComponent<Image>().sprite = pumpkinSprite;
                    break;
                case Seed.CUCUMBER_NAME:
                    currentlyHoldingObj.GetComponent<Image>().sprite = cucumberSprite;
                    break;
            }
            currentlyHoldingObj.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void PourWater() {
        isWatered = true;
    }

    public void CollectCrop() {
        if (currentlyHoldingObj != null) {
            currentlyHoldingObj.SetActive(false);
            currentlyHoldingObj.GetComponent<Image>().sprite = seedSprite;
            currentlyHoldingObj.GetComponent<BoxCollider2D>().enabled = true;
            currentlyHoldingObj = null;
        }
    }

}
