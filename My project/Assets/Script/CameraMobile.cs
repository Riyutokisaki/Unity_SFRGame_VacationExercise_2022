using UnityEngine;

public class CameraMobile : MonoBehaviour
{

    public Transform target; // 要觀看的目標

    float temp;
    bool sw = false;

    Vector2 m_screenPos;

    void Update()
    {
        if (Input.touchCount <= 0)
            return;
        if (Input.touchCount == 1) //單點觸碰移動攝像機
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                m_screenPos = Input.touches[0].position;   //記錄手指剛觸碰的位置
            if (Input.touches[0].phase == TouchPhase.Moved) //手指在螢幕上移動，移動攝像機
            {
                transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, Input.touches[0].deltaPosition.y * Time.deltaTime * -1, 0));
            }
        }
        if (Input.touchCount >= 2)
        {
            float temp2 = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            float cameraScale = temp2 - temp;
            temp = temp2;
            if (sw)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position, target.position, cameraScale * Time.deltaTime / 2);
            }
            sw = true;
        }
        else
        {
            sw = false;
        }
        //Camera.main.transform.Translate( Vector3.forward * Time.deltaTime );

    }
}