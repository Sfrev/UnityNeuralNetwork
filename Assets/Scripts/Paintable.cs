using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    [SerializeField] private GameObject brush = null;
    [SerializeField] private float brushSize = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject gObject = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                gObject.transform.localScale = Vector3.one * brushSize;
                Destroy(gObject, 0.2f);
            }
        }
    }
}
