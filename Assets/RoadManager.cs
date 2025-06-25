using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class RoadManager : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    GameObject _bunny;
    CharBehaviour _charBehaviourrr;

    public float _cSpeed = 2f;
    public bool _unSpawnable;

    private void Start()
    {
        _bunny = GameObject.Find("Circle");
        _charBehaviourrr= _bunny.GetComponent<CharBehaviour>();
        _unSpawnable=false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_charBehaviourrr.gameover) {
            gameObject.transform.Translate(new Vector2(0f,- _cSpeed));
        }
        
    }

    private void OnTriggerExit2D(Collider2D desRoad)
    {
        if (desRoad.gameObject.name == "OutOfScene") {
            if(!_unSpawnable && !_charBehaviourrr.gameover ) SpawnRoad();
            Destroy(gameObject,0.1f);
        }
    }

    public void OnApplicationQuit()
    {
       _unSpawnable = true;
    }

    public void SpawnRoad()
    {
       
        Instantiate(prefab,new Vector3(0f, 8.5f,0f), Quaternion.identity);

    }

    public void SetInitialRoads()
    {
        float roadPosition = 6.5f;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(prefab, new Vector3(0f, roadPosition, 0f), Quaternion.identity);
            roadPosition += 4;
        }
    }
    
}
