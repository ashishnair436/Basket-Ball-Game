using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            Player.instance.AddScore(1);
            Debug.Log("Score");

        }
    } 
}
