using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    public float carSpeed;
    bool _isGoingRight;
    GameObject _road;
    RoadManager _roadManager;
    

    GameObject _bunny;
    CharBehaviour _charBehaviour;

    void Start()
    {

        _bunny = GameObject.FindWithTag("Player");
        _charBehaviour = _bunny.GetComponent<CharBehaviour>();
        _road = GameObject.FindWithTag("Road");
        _roadManager = _road.GetComponent<RoadManager>();
        

        

        if (transform.position.x > 15) _isGoingRight = false;
        else if (transform.position.x <15) _isGoingRight = true;   
    }

   
    void Update()
    {
        if(transform.position.x>31 || transform.position.x<-31)  Destroy(gameObject);


        if (Input.GetKeyDown("space") && !_charBehaviour.gameover)
        {
            gameObject.transform.Translate(new Vector2(0f, - _roadManager._cSpeed));
        }

        if (_isGoingRight) transform.Translate(new Vector2(carSpeed * Time.deltaTime, 0f));
        else if(!_isGoingRight) transform.Translate(new Vector2(-carSpeed * Time.deltaTime, 0f));
    }

    
}
