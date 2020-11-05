using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 10f;
        transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
