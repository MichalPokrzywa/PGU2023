using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the swapping of active cameras in the game.
/// </summary>
public class ChangeCamera : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject bomb;

    void Start()
    {
        // Disable one of the cameras initially
        camera1.SetActive(true);
        camera2.SetActive(false);
        bomb.SetActive(true);
    }

    /// <summary>
    /// Swaps the active cameras.
    /// </summary>
    public void SwapCameras()
    {
        GameManager.instance.isInWalkMode = !GameManager.instance.isInWalkMode;
        camera1.SetActive(!camera1.activeSelf);
        camera2.SetActive(!camera2.activeSelf);
        bomb.SetActive(!bomb.activeSelf);
    }
}
