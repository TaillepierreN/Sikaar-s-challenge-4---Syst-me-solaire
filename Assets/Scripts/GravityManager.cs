using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject sun;
    float revolution;
    float rotation;
    void Start()
    {
        if(gameObject.CompareTag("mercury")){revolution= 4.787f;rotation =1.083f;}
        if(gameObject.CompareTag("venus")){revolution= 3.502f;rotation = 0.652f;}
        if(gameObject.CompareTag("earth")){revolution= 2.978f;rotation = 15.74f;}
        if(gameObject.CompareTag("mars")){revolution= 2.4077f;rotation = 8.66f;}
        if(gameObject.CompareTag("jupiter")){revolution= 1.307f;rotation =455.83f;}
        if(gameObject.CompareTag("saturn")){revolution= 0.969f;rotation =368.40f;}
        if(gameObject.CompareTag("uranus")){revolution= 0.681f;rotation =147.94f;}
        if(gameObject.CompareTag("neptune")){revolution= 0.543f;rotation =97.19f;}

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.transform.position,Vector3.up, revolution * Time.deltaTime);
        transform.Rotate(0,rotation*Time.deltaTime,0);
    }
}
