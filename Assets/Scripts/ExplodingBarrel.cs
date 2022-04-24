using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    private Animator anim;
    public UI ui;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ui = GameObject.Find("UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Explode() {
        anim.SetTrigger("ExplodeTrigger");
        yield return new WaitForSeconds(0.5f);
        ui.PlayerDeath();
        Destroy(gameObject);
    }
}
