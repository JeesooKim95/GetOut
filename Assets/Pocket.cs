using UnityEngine;
using System.Collections;

public class Pocket : MonoBehaviour
{
    public GameObject magazine;

    public void DrawMagazine()
    {
        Instantiate(magazine, gameObject.transform.position, Quaternion.identity);
        //XRInteractionManager.ForceSelect(interactionM, obj);
    }
}
