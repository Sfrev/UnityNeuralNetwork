using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private GameObject brush = null;

    private GameObject trail;
    private Plane plane;
    private Vector3 startPosition = default;

    void Start()
    {
        plane = new Plane(Camera.main.transform.forward * -1, transform.position);
    }

    void Update()
    {
        TouchDraw();

        if (Input.GetMouseButtonDown(1))
        {
            EraseAll();
        }
    }

    private static void EraseAll()
    {
        TrailRenderer[] trailRendererArray = FindObjectsOfType<TrailRenderer>();

        foreach (TrailRenderer trailRenderer in trailRendererArray)
        {
            Destroy(trailRenderer.gameObject);
        }
    }

    private void TouchDraw()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            trail = Instantiate(brush, transform.position, Quaternion.identity);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (plane.Raycast(mouseRay, out distance))
            {
                startPosition = mouseRay.GetPoint(distance);
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (plane.Raycast(mouseRay, out distance))
            {
                trail.transform.position = mouseRay.GetPoint(distance);
            }
        }
    }
}
