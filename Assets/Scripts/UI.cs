using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Dialogue dialogue;
    public Image portrait;
    public Sprite assistantPortrait;
    public Sprite robotPortrait;
    // Start is called before the first frame update
    void Start() {
        dialogue = transform.Find("Canvas").transform.Find("Dialogue").gameObject.GetComponent<Dialogue>();
        portrait = transform.Find("Canvas").transform.Find("Portrait").gameObject.GetComponent<Image>();
        WelcomeDialogue();
    }

    public void PlayerDeath() {
        transform.Find("Canvas").transform.Find("Filter").gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.2f);
    }


    private void SetPortrait(string type) {
        if (type == "assistant") {
            portrait.sprite = assistantPortrait;
        } else if (type == "robot") {
            portrait.sprite = robotPortrait;
        }
    }

        public IEnumerator Wait(int seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public void WelcomeDialogue() {
        SetPortrait("assistant");
        dialogue.PrintText("This is some sample dialogue!");
    }
}
