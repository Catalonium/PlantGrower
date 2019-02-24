using UnityEngine;

public class Field : MonoBehaviour {

	public Seed pickedCrop;
    // To check whether the pour water on this field or not
	public bool isWatered;
    // To check whether the crop exist on this field or not
    public bool hasCrop;
    // Number of seconds to change crop
    public float sec;
    // TODO comment
	public int timer;

	void Start()
	{
        // set timer and stuff (for individual crop field)
        isWatered = false;
        timer = 0;
	}

	void Update()
	{
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
        if(sec >= 15) {
            sec = 0;
            isWatered = false;
        }
    }

    public void PourWater() {
        isWatered = true;
    }

}
