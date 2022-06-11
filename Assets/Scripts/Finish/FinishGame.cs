using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject _plate;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private CheckPoint _checkPoint;

    private void Update()
    {
        if (_checkPoint.Finished)
        {
            _pauseMenu.SetActive(false);
            _plate.SetActive(true);
        }
    }
}
