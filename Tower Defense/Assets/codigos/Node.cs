﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;
  
   

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        buildManager.BuildTurretOn(this);


    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        rend.material.color = hoverColor;
        if (! buildManager.CanBuild) return;  
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
