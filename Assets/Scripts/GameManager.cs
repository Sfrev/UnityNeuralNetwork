using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Screenshot")]
    [SerializeField] private ScreenshotManager screenshotManager;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            screenshotManager.TakeScreenshot();
        }
    }
}
