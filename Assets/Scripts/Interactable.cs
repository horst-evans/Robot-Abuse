using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public static UnityEvent AttachEvent;
    public static UnityEvent DettachEvent;

    private bool wasAttached = true;

    // highlight variables
    [Header("Highlight Settings")]
    public bool useHighlighting = true;
    public Material highlightMaterial;

    // movement variables
    private Vector3 screenPoint;
    private Vector3 offset;

    // snapping variables
    [Header("Snap Settings")]
    public Transform snapPoint;
    public float snapDistance = 0.05f;

    private void Awake()
    {
        AttachEvent = new UnityEvent();
        DettachEvent= new UnityEvent();
    }

    private void OnMouseEnter()
    {
        if (useHighlighting)
        {
            EnableHighlight();
        }
    }

    private void OnMouseExit()
    {
        if (useHighlighting)
        {
            DisableHighlight();
        }
    }

    // Get:
    // - the screen point of gameobject
    // - and offset of mouse from said point
    // at the beginning of the drag
    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        if (snapPoint != null && wasAttached && transform.position != snapPoint.position)
        {
            DettachEvent.Invoke();
            wasAttached = false;
        }
        else if (snapPoint != null && !wasAttached && transform.position == snapPoint.position)
        {
            AttachEvent.Invoke();
            wasAttached = true;
        }
    }

    // Move transform to current position.
    private void OnMouseDrag()
    {
        // dont de-parent if interactable cant do snapping
        if (snapPoint != null)
        {
            transform.parent = null;
        }

        Vector3 curScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;

        if((snapPoint != null) && (Vector3.Distance(curPosition, snapPoint.position) < snapDistance))
        {
            transform.position = snapPoint.position;
            transform.parent = snapPoint.parent;
        }
    }

    #region Helper Functions
    private void EnableHighlight()
    {
        foreach (Renderer render in GetComponentsInChildren<MeshRenderer>())
        {
            Material[] materialsArray = new Material[(render.materials.Length + 1)];
            render.materials.CopyTo(materialsArray, 0);
            materialsArray[materialsArray.Length - 1] = highlightMaterial;
            render.materials = materialsArray;
        }
    }

    private void DisableHighlight()
    {
        foreach (Renderer render in GetComponentsInChildren<MeshRenderer>())
        {
            Material[] materialsArray = new Material[(render.materials.Length - 1)];
            Array.Copy(render.materials, materialsArray, render.materials.Length - 1);
            render.materials = materialsArray;
        }
    }
    #endregion
}
