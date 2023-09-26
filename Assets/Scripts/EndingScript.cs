using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public bool dead = false;
    public bool win = false;
    [SerializeField] GameObject dieText;
    [SerializeField] GameObject winText;

    // Update is called once per frame
    void Update()
    {
        
        ///if dead
        if (dead)
        {
            dieText.gameObject.SetActive(true);

        }

        if (Input.GetKey(KeyCode.Space) && dead)
        {
            dead = false;
            dieText.gameObject.SetActive(false);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        //if win
        if (win)
        {
            winText.gameObject.SetActive(true);

        }

        if (Input.GetKey(KeyCode.Space) && win)
        {
            win = false;
            winText.gameObject.SetActive(false);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

    }
    //win or lose states = true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            dead = true;
            //Debug.Log("dead = " + dead);

        }

        if (collision.gameObject.layer == 9)
        {
            win = true;
            //Debug.Log("dead = " + dead);

        }

    }
    
}
