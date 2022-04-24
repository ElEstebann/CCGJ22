using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Dialogue dialogue;
    public Image portrait;
    public Sprite assistantPortrait;
    public Sprite SLAPortrait;
    // Start is called before the first frame update
    void Start() {
        dialogue = transform.Find("Canvas").transform.Find("Dialogue").gameObject.GetComponent<Dialogue>();
        portrait = transform.Find("Canvas").transform.Find("Portrait").gameObject.GetComponent<Image>();
        StartCoroutine(Level1Dialogue());
    }

    public void PlayerDeath() {
        transform.Find("Canvas").transform.Find("Filter").gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.2f);
    }


    private void SetPortrait(string type) {
        if (type == "assistant") {
            portrait.sprite = assistantPortrait;
        } else if (type == "SLAPortrait") {
            portrait.sprite = SLAPortrait;
        }
    }

    public IEnumerator Wait(int seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public IEnumerator Level1Dialogue() {
        SetPortrait("SLAPortrait");
        dialogue.PrintText("Hello! Thank you for enabling the Student Lab Companion. It seems that you are trapped in the Knox Laboratories Laser research facility. I will do my best to contact someone who can let you out.");
        yield return new WaitForSeconds(15);
        dialogue.PrintText("As it is an academic holiday and 3 in the morning, no one is available to let you out. Following emergency protocols, I will guide you out of the facility. Listen" +
        "carefully and do exactly as I say.");
    }
}
