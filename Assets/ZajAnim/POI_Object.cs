using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class POI_Object : MonoBehaviour
{
    public Rig rig;
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
        while (rig.weight < 1 && inTrigger)
        {
            var newWeight = math.lerp(rig.weight, 1,Time.deltaTime *2);
            rig.weight = newWeight;
            yield return null;
        }
    }

    public IEnumerator LerpOut()
    {
        while (rig.weight >0 && !inTrigger)
        {
            var newWeight = math.lerp(rig.weight, 0, Time.deltaTime * 2);
            rig.weight = newWeight;
            yield return null;
        }
    }
}
