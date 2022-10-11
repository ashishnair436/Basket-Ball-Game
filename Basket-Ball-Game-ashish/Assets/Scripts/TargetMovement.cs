using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{

    public GameObject hoop;

    public float hoopspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
       // hoop.transform.position = new Vector3(0, 4.25f, 17.11f);
    }

    // Update is called once per frame
    void Update()
    {
        hoop.transform.Translate(Vector3.right * hoopspeed * Time.deltaTime);

        if(hoop.transform.position.x >= 3.4f)
        {
            hoopspeed = -2f;
        }
        if (hoop.transform.position.x <= -3.4f)
        {
            hoopspeed = 2f;
        }


    }
}
