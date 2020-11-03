﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private GameObject brush = null;
    //[SerializeField] private float brushSize = 0.1f;

    private GameObject trail;
    private Plane plane;
    //private GameObject ink = null;
    private Vector3 startPosition = default;

    void Start()
    {
        plane = new Plane(Camera.main.transform.forward * -1, transform.position);
    }

    void Update()
    {
        //MouseDraw();
        TouchDraw();
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
    /*
    private void MouseDraw()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ink = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                ink.transform.localScale = Vector3.one * brushSize;
            }
        }
        if (Input.GetMouseButtonUp(0) && ink)
        {
            Destroy(ink);
        }
    }*/
}