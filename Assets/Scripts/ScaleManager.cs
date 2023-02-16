using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleManager : MonoBehaviour
{
    public XRBaseInteractor leftInteractor;
    public XRBaseInteractor rightInteractor;
    // Start is called before the first frame update
    float prevHandDistance;
    float movedDistance;
        public GameObject solsys;
    public GameObject leftHand;
    public GameObject rightHand;

    void Update()
    {
        bool leftGrip = leftInteractor.hasSelection && leftInteractor.interactablesSelected[0].transform.gameObject == gameObject;
        if (leftGrip)
        {
        Debug.Log("left");
            if (rightInteractor.IsHovering(gameObject.GetComponent<XRGrabInteractable>()))
            {
        Debug.Log("and right");

                float handDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
                if(handDistance != prevHandDistance)
                {
                movedDistance = handDistance - prevHandDistance;
                solsys.transform.localScale = solsys.transform.localScale + (Vector3.one * (movedDistance*5f));
                gameObject.transform.localScale = gameObject.transform.localScale + (new Vector3(1,0.1f,1) * (movedDistance));
                }
                prevHandDistance = handDistance;
   
            }

        }
    }
}
