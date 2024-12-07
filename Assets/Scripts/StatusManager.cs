using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public GameObject attachMessage;
    public GameObject detachMessage;
    private int numDetached = 0;

    public static StatusManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Interactable.AttachEvent.AddListener(OnAttach);
        Interactable.DettachEvent.AddListener(OnDetach);
    }

    private void OnDestroy()
    {
        Interactable.AttachEvent?.RemoveListener(OnAttach);
        Interactable.DettachEvent?.RemoveListener(OnDetach);
    }

    public void OnAttach()
    {
        numDetached--;
        if (numDetached == 0)
        {
            attachMessage.SetActive(true);
            detachMessage.SetActive(false);
        }
    }

    public void OnDetach()
    {
        numDetached++;
        attachMessage.SetActive(false);
        detachMessage.SetActive(true);
    }

    public int GetDetached()
    {
        return numDetached;
    }
}
