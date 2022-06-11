using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    string _nextLevelName = "Level1";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Go to level " + _nextLevelName);
            SceneManager.LoadScene(_nextLevelName);
        }
    }

}
