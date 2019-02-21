using UnityEngine;

public class Field : MonoBehaviour {

	public Seed pickedCrop;
	bool isWatered;
	int timer;

	void Start()
	{
		// set timer and stuff (for individual crop field)
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
	}

}
