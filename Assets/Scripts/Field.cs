using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour {

    Score score;

    // To check whether the pour water on this field or not
    public bool isWatered;
    // To check whether plant has grown or not
    public bool isGrown;
    // To check whether the crop exist on this field or not
    public bool hasCrop;
    // Number of seconds to change crop
    public float sec;
    // currently holding crop on this field
    public Seed currentlyHoldingObj;
    // sprite for eggplant crop
    public Sprite eggplantSprite;
    // sprite for pumpkin crop
    public Sprite pumpkinSprite;
    // sprite for cucumber crop
    public Sprite cucumberSprite;
    // sprite for seed
    public Sprite seedSprite;
    // crop change from plant to vegetable time constant
    private const int CROP_TIMER = 5;

    void Start() {
        isWatered = false;
        isGrown = false;
        hasCrop = false;
        // init score script
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update() {
        // TODO this is where crops should be held (from placed seeds)
        // so that seeds will "turn" into crops, and will "grow" here

        // if clicked with a crop, assign it to currentCrop
        // assign growTime to timer

        // if clicked with pot, isWatered true
        // start timer count down

        // if timer ends, reset the field and add grown plant's score to background scores

        if (isWatered && !isGrown) {
            GrowOnWater();
        }
    }

    void GrowOnWater() {
        sec += Time.deltaTime;
        if (sec >= CROP_TIMER && currentlyHoldingObj != null) { // null control is to prevent an occasional error, further testing beneficial
            sec = 0;
            isGrown = true;
            switch (currentlyHoldingObj.seedName) {
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
        }
    }

    public void PourWater() {
        isWatered = true;
    }

    public void CollectCrop() {
        if (currentlyHoldingObj != null) {
            // set score
            score.AddScore(currentlyHoldingObj.score);
            // reset current crop-tile
            currentlyHoldingObj.gameObject.SetActive(false);
            currentlyHoldingObj.gameObject.GetComponent<Image>().sprite = seedSprite; // *****
            currentlyHoldingObj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            currentlyHoldingObj = null;
            isWatered = false;
            isGrown = false;
            hasCrop = false;
        }
    }

}
