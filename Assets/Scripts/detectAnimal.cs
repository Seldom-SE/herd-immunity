using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectAnimal : MonoBehaviour
{
    public string animalTag;
    private int animals;
    private GameObject[] animalArr;
    private int maxAnimals;

    public AudioSource AnimalSound;

    public GameObject completedMessage;

    public bool winnable = false;
    // Start is called before the first frame update
    void Start()
    {
        animals = 0;
        animalArr = GameObject.FindGameObjectsWithTag(animalTag);
        maxAnimals = animalArr.Length;
        completedMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col){
        UnityEngine.Debug.Log("Something entered");
        if(col.tag == animalTag){
            animals++;

            if(animals == maxAnimals){
                UnityEngine.Debug.Log(animalTag + " win");
                winnable = true;
                completedMessage.SetActive(true);
                AnimalSound.Play();
                DestroySound(2f);
            }
        }
    }

    void OnTriggerExit(Collider col){
        UnityEngine.Debug.Log("Something Exited");
        if(col.gameObject.tag == animalTag){
            animals--;

            winnable = false;
        }
    }

     IEnumerator DestroySound(float time)  //Prevent constant animal sound
     {
         yield return new WaitForSeconds(time);
 
        Destroy(AnimalSound);
    }
}
