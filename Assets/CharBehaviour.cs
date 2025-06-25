using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharBehaviour : MonoBehaviour
{
    [SerializeField] RoadManager _roadManageree;
    
    public int score;
    public bool gameover;
    private void Start()
    {
        gameover = false;
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car") { 
            gameover = true; 
            _roadManageree._unSpawnable = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Road")
        {
            score += 10;
            Debug.Log(score);
        }
    }
}
