using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ConversationController : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Rig talkRig1;
    public Rig talkRig2;
    public Rig stareRig1;
    public Rig stareRig2;

    private bool inTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        inTrigger = true;
        StartCoroutine(LerpIn());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        inTrigger = false;
        StartCoroutine(LerpOut());
    }

    public IEnumerator LerpIn()
    {
        anim1.SetBool("inTrigger", true);
        anim2.SetBool("inTrigger", true);
        while (stareRig1.weight < 1 && inTrigger)
        {
            stareRig1.weight += 0.01f;
            stareRig2.weight += 0.01f;
            talkRig1.weight -= 0.01f;
            talkRig2.weight -= 0.01f;
            yield return null;
        }
    }

    public IEnumerator LerpOut()
    {
        anim1.SetBool("inTrigger", false);
        anim2.SetBool("inTrigger", false);
        while (stareRig1.weight > 0 && !inTrigger)
        {
            stareRig1.weight -= 0.01f;
            stareRig2.weight -= 0.01f;
            talkRig1.weight += 0.01f;
            talkRig2.weight += 0.01f;
            yield return null;
        }
    }
}
