using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

   [SerializeField]
    private  GameObject _ball;
   [SerializeField]
   private GameObject _playerCamera;
    [SerializeField]
    private float _ballDistance = 2f;

   public bool _holdingBall = true;

    public int _score = 0;



    //public float resetTimer = 3f;


    [SerializeField]
    private float _ballThrowingForce = 550f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _ball.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
         if (_holdingBall)
         {

             _ball.transform.position = _playerCamera.transform.position + _playerCamera.transform.forward * _ballDistance;

             if (Input.GetMouseButtonDown(0))
             {
                 _holdingBall = false;
                
                 _ball.GetComponent<Rigidbody>().useGravity = true;
                 _ball.GetComponent<Rigidbody>().AddForce(_playerCamera.transform.forward * _ballThrowingForce);
                StartCoroutine(BasketballCoroutine());
             }

         }

    }



        IEnumerator BasketballCoroutine()
        {
        
        yield return new WaitForSeconds(3f);
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //_ball.GetComponent<Rigidbody>().angularDrag = 0f;
        _ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        _holdingBall = true;

        _ball.GetComponent<Rigidbody>().useGravity = false;
        
        }

    public void AddScore(int points)
    {
        _score = _score + points;
        UIManager.instance.UpdateScore(_score);

        UIManager.instance.CheckForBestScore(_score);

    }

}
