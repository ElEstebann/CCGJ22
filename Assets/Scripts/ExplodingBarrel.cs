using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    private Animator anim;
    public GameController controller;
    bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Explode() {
        if (!exploded)
        {
            exploded = true;
            anim.SetTrigger("ExplodeTrigger");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Boom! You lose.");
            controller.Lose();
        }
    }

}
