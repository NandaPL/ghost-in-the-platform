using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    [SerializeField] GameObject _player;
    [SerializeField] float _finish;

    
    // Update is called once per frame
    void Update()
    {
        if (EndOfLevel())
            GoToNextLevel();
    }

    bool EndOfLevel()
    {
        if (_player.transform.position.x < _finish)
        {
            return false;
        }

        return true;
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }
}
