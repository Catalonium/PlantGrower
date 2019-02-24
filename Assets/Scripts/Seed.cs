using UnityEngine;

[System.Serializable]
public class Seed : MonoBehaviour {

    public const string EGGPLANT_NAME = "Eggplant";
    public const string PUMPKIN_NAME = "Pumpkin";
    public const string CUCUMBER_NAME = "Cucumber";

    public string seedName;
    public float growingTime;
    public int score;

}
