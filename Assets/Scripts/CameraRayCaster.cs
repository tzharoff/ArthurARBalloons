using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCaster : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            TouchPhase mainTouch = Input.GetTouch(0).phase;
            if(mainTouch == TouchPhase.Ended || mainTouch == TouchPhase.Canceled)
            {
                if(Physics.Raycast(camera.ScreenPointToRay(Input.GetTouch(0).position), out RaycastHit hit)){
                    if (hit.collider.gameObject.CompareTag("Balloon"))
                    {
                        hit.collider.gameObject.GetComponent<Balloon>().PopBalloon();
                    }
                }
            }
        }
    }
}
