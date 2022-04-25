using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaitUntilDOne : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime;
    public string nextScene;
    void Start()
    {
        StartCoroutine(WaitAndTransition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndTransition()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextScene);
    }
}
