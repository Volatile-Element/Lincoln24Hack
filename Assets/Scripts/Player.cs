using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoffinObject CarryingPartObject;
    public bool CarryingPart;
    public bool Paused = false;

    public GameObject GrabHand;
    public GameObject CarryingHands;

    public InteractableMono InteractableItemInFocus;

    private float _InteractionDistance = 2;

    public StringUnityEvent OnCarryingChange = new StringUnityEvent();

    private void Awake()
    {
        GrabHand = gameObject.GetComponentInChildren<GrabHand>().gameObject;
        CarryingHands = transform.GetComponentInChildren<CarryingHands>().gameObject;
        CarryingHands.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Paused)
        {
            return;
        }

        ScanForInteraction();
        ManageInput();
    }

    public void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && InteractableItemInFocus != null)
        {
            InteractableItemInFocus.Interact();
        }
    }

    public void ScanForInteraction()
    {
        RaycastHit hit;
        var cam = GetComponentInChildren<Camera>().transform;
        var loweredCamPosition = new Vector3(cam.position.x, cam.position.y - 0.5f, cam.position.z);

        Debug.DrawRay(cam.position, cam.forward * _InteractionDistance, Color.blue);
        if (Physics.Raycast(cam.position, cam.forward, out hit, _InteractionDistance))
        {
            InteractableItemInFocus = hit.transform.gameObject.GetComponent<InteractableMono>();
            if (InteractableItemInFocus != null)
            {
                if (InteractableItemInFocus.IsCurrentlyInteractable())
                {
                    HoverTextManager.Instance.DisplayText(InteractableItemInFocus.GetText());
                }
                else
                {
                    HoverTextManager.Instance.ClearText();
                    InteractableItemInFocus = null;
                }
            }
            else
            {
                HoverTextManager.Instance.ClearText();
                InteractableItemInFocus = null;
            }
        }
        else
        {
            HoverTextManager.Instance.ClearText();
            InteractableItemInFocus = null;
        }
    }

    public void StartCarryingItem(CoffinObject part)
    {
        CarryingPartObject = part;
        CarryingPart = true;

        CarryingHands.SetActive(true);
        GrabHand.SetActive(false);

        OnCarryingChange.Invoke(part.Name);
    }

    public void StopCarryingItem()
    {
        CarryingPartObject = null;
        CarryingPart = false;

        CarryingHands.SetActive(false);
        GrabHand.SetActive(true);

        OnCarryingChange.Invoke("");
    }
}