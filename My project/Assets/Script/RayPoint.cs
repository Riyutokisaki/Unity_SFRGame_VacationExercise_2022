using UnityEngine;

public class RayPoint : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch= Input.GetTouch(0);
            Camera.main.ScreenPointToRay(touch.position);
        }
        
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;

        print("重力感測X" + x);
        print("重力感測y" + y);
        print("重力感測z" + z);
    }
}
