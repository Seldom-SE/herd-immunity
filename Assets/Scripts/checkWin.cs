using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkWin : MonoBehaviour
{
    private GameObject[] detectors;
    public bool winState = false;

    public AudioSource winSound;

    public GameObject loseMessage;

    public GameObject winMessage;

    public float gameTime;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        detectors = GameObject.FindGameObjectsWithTag("Detector");
        loseMessage.SetActive(false);
        winMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!winState){
            foreach(GameObject detector in detectors){
                if(detector.GetComponent<detectAnimal>().winnable){
                    winState = true;
                }
                else{
                    winState = false;
                    break;
}
            }
            if(winState){
            UnityEngine.Debug.Log("WIN!");
            winSound.Play();
            winMessage.SetActive(true);
}
        }
        gameTime -= 1 * Time.deltaTime;

        string minutes = ((int) gameTime/60).ToString();
        string seconds = (gameTime % 60).ToString("f0");

        timerText.text= minutes + ":" + seconds;


        if(gameTime < 0)
        { //LOSE
            loseMessage.SetActive(true);
        }
    }
}
