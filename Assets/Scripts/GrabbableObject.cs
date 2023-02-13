using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private XRDirectInteractor directInteractor;
    private Vector3 startScale;
    private Vector3 startHandPositionL;
    private Vector3 startHandPositionR;
    private bool isScaling = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        directInteractor = GetComponent<XRDirectInteractor>();
        startScale = transform.localScale;
    }

    private void OnEnable()
    {
        directInteractor.onHoverEnter.AddListener(StartScaling);
        directInteractor.onHoverExit.AddListener(StopScaling);
    }

    private void OnDisable()
    {
        directInteractor.onHoverEnter.RemoveListener(StartScaling);
        directInteractor.onHoverExit.RemoveListener(StopScaling);
    }

    private void Update()
    {
        if (isScaling)
        {
            var handPositionL = directInteractor.interactions[0].interactor.transform.position;
            var handPositionR = directInteractor.interactions[1].interactor.transform.position;
            var newScale = startScale * Vector3.Distance(handPositionL, handPositionR) / Vector3.Distance(startHandPositionL, startHandPositionR);
            transform.localScale = newScale;
        }
    }

    private void StartScaling(XRBaseInteractable interactable)
    {
        if (directInteractor.interactions.Count == 2)
        {
            isScaling = true;
            startHandPositionL = directInteractor.interactions[0].interactor.transform.position;
            startHandPositionR = directInteractor.interactions[1].interactor.transform.position;
        }
