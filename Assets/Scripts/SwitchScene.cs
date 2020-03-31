using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int scene_Index;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoader(scene_Index);
        }
    }
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
