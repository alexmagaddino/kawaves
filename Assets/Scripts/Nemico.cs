using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemico : MonoBehaviour
{
    float speed;
    public float timer, count;
    public bool HoV;
    void Start()
    {
        speed = 5;
        timer = count;
    }

    void Update()
    {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (speed == 5)
                    speed = -5;
                else if (speed == -5)
                    speed = 5;
                timer = count;
            }
            if(HoV)
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
            else
                transform.Translate(new Vector3(0,speed * Time.deltaTime, 0), Space.World);
    }

    

}
