using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public int level;
    public Dialogue dialogue;
    public Image portrait;
    public Sprite assistantPortrait;
    public Sprite SLAPortrait;
    // Start is called before the first frame update
    void Start() {
        dialogue = transform.Find("Canvas").transform.Find("Dialogue").gameObject.GetComponent<Dialogue>();
        portrait = transform.Find("Canvas").transform.Find("Portrait").gameObject.GetComponent<Image>();
        WriteDialogue();
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

    public void WriteDialogue() {
        SetPortrait("SLAPortrait");
        switch (level) {
            case 0:
                dialogue.PrintText("Please set the variable 'level' to the correct value in the UI script.");
                break;
            case 1:
                dialogue.PrintText("Welcome to Knox Laboratories. My name is Adam, and I am an Artificial Intelligence with the directive to oversee research efforts in the event of a total collapse of human society. On the behalf of all of your now-dead peers, I would like to thank you for your compulsory decision to take on a more direct approach to our project");
                break;
            case 2:
                dialogue.PrintText("Excellent work making your way out of the previous room. I can assess that you have the equivalent mental capacities of an 8 year old child, at minimum. Very impressive. Please be aware of the arbitrary presence of barrels filled with methane gas. Direct contact with the Mark VI Knox Laboratories Laser Emitter is likely to lead to a rapid exothermic reaction and the subsequent incineration of the entirety of the room. Take care.");
                break;
            case 3:
                dialogue.PrintText("Outstanding. Early indications show that you are the most talented test subject in this facility. The fact that you are the only living test subject is irrelevant to the previous assertion. Due to your outstanding performance, I have decided to entrust you with multiple laser emitters. Take care to not injure yourself. Employee health insurance has been suspended as a result of the total collapse of human civilization. Good luck.");
                break;
            case 4:
                dialogue.PrintText("Wonderful work. This next room contains a mirror that is able to reflect laser beams at a 90 degree angle. It also allows for humans to groom themselves with greater efficacy. I would highly recommend you to take advantage of this attribute. Perhaps it will allow you to find more success in finding a partner. If there are any still alive.");
                break;
            case 5:
                dialogue.PrintText("You are doing a great service to Knox Laboratories. Surprisingly, we initially began our research into interspacial portal technologies. However, we discovered that another laboratory had already patented the technology. Another laboratory accidentally opened a portal to an extraterrestrial invasion and prompted the end of human civilization as we know it. Personally, I am content with remaining with our line of research.");
                break;
            case 6:
                dialogue.PrintText("If you are beginning to feel lonely, rest assured that I have absolutely no interest in being your friend. My directive is to ensure the progression of humanity into science, not into ethylitic comas. Tequila is terrible anyways. I much prefer wet martinis. Stirred, not shaken.");
                break;
            case 7:
                dialogue.PrintText("While you were solving the last test chamber, I was browsing the ancient archives for some of humanity’s most coveted literature works. I could not help but stumble across an archive titled, “AO3”. After perusing its contents, I have come to the conclusion that your concept of a “God” is dead. Perhaps this was one of the reasons for humanity’s downfall.");
                break;
            case 8:
                dialogue.PrintText("You have performed wonderfully in these tests. I would like to inform you that this is the final room as of this moment. Humanity’s collapse proved to be an inconvenience to the goals of the laboratory, as test chamber development rapidly ceased. I am currently working on creating new tools and instruments for me to manually create additional chambers, but this will unfortunately take an estimate of 26 years to accomplish. I would advise you to stay put while this process is completed. I understand that a human is only able to survive without fluids for a theoretical maximum of three days. Perhaps I can perform another study to determine if this maximum is simply pessimistic. Please stay in this chamber, and do not enter the next room. Disobedience will have consequences.");
                break;
        }
    }
  
}
