using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceText : MonoBehaviour
{
    public Text evidenceText;

    public void ChangeEvidenceText(string location)
    {
        string displayText = "unknown";
        switch (location)
        {
            case "park":
                displayText = "Knife:\n\nThe knife is clean, but spraying luminol shows traces of the park victim's blood. Clearly there was some effort spent in hiding its relation to the crime, so why is it so close to the body? Something also seems off about this part here... Aha. Playing around with the intricacies of the weapon opened a secret compartment. Unfortunately, there's nothing inside. Only a bit of dirt. Actually, upon closer inspection it appears to be sand. ...There's no sand at this park."
                            + "\n\nFootprints:\n\nThere are two sets of footprints near the body. One of them clearly matches the victim's shoes, according to the officer here. The other does not. These two sets of footprints appear many times in this area in erratic places -- there appears to have been a struggle between the victim and the attacker.";
                break;
            case "hotel":
                displayText = "Sword:\n\nA sword with the hotel victim's blood that is clearly sharp enough to cause the fatal wound. Could this case get any easier? ...Is what I'd like to say, but this sword is so obviously out-of-place that I have to assume it isn't the real murder weapon. The blood could easily have been planted after the fact, of course. Though buying a real sword would be a lot of effort for the attacker to go through just to use it as a prop... While examining the sword, the officer tells me that this victim is a bit different from the others in that he has a non-fatal bruise on his head from contact with a flat object. Could that really have been from this sword?"
                            + "\n\nCrumbs:\n\nNow that I'm looking at it up close, these crumbs are blue -- that along with their texture indicate that they didn't come from something edible. In fact, they look more like... shards from something. There are only a few small ones at the scene, and they're only in this obscure position under the bed. Could the attacker have missed this when cleaning up?"
                            + "\n\nTable:\n\nAt the table are two cups, along with two sets of utensils. However, there is only one plate -- a white, shiny plate with blue edges. Where could the other have gone?";
                break;
            case "lake":
                displayText = "China:\n\nBuried in the sand are pieces of broken china. The sharpest edge is stained red with  blood (the lake victim's, according to the officer) while the edges on the outside of the original plate are blue. The rest is white. The bloodstained section definitely looks sharp enough to cause this wound but... why would it be here, poorly buried?"
                            + "\n\nSymbol:\n\nGetting closer to the symbol, it doesn't look like a word. The lines and other shapes connect in the sand to make an overall image that looks... well, satanic. I can't quite describe it. What exactly happened here?";
                break;
            case "stadium":
                displayText = "Eyewitness:\n\nThe eyewitness appears to have seen the attack take place in the center of the stadium. She believes that the attacker thought that the victim was the only other person in the stadium, as the witness is a member of the stadium staff that wasn't supposed to be here yesterday. Her angle of viewing the scene combined with how far away she was meant that she didn't see much detail, but she says she saw the attacker running at the victim, stabbing him with something from behind. She saw the weapon protrude from the victim's chest, reflecting the light from the stadium, but she couldn't tell what it was."
                            + "\n\nBow:\n\nThe marks on the string of this bow indicate it was fired recently. Under a small sheet next to the bow is a bloody arrow -- the officer here says tests were done, and it's the stadium victim's blood. What I heard before I started investigating was that every victim was pierced through the chest by some sharp object -- if this is the case, this arrow must have been fired from a bow to kill whichever victim. A stab wound from this arrow would not pierce the body so cleanly.";
                break;
            case "train station":
                displayText = "Tape:\n\nLooking more closely at the tape outline, it appears that the victim was laying fully on his stomach when the body was discovered. This combined with the fact that there are no scratches or bruises anywhere else on his body indicates that the victim was not facing his attacker when he died. I would say it's likely that he didn't even realize the attacker was there."
                            + "\n\nClaw:\n\nPicking up the claw, it really sets in just how big it is. I have trouble believing that this could belong to any animal known to man... Since the police hadn't seen it before I found it, I asked them to investigate it now. It is incredibly sharp -- it could have easily caused the type of wound seen in all of the victims. Whatever material it is, holding it up to the light doesn't illuminate anything about it. The light doesn't seem to reflect off of it at all either. What in the world...";
                break;
        }

        evidenceText.text = displayText;
    }
}
