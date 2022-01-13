using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script handle all the control code, so detecting when the users click on a unit or building and selecting those
/// If a unit is selected it will give the order to go to the clicked point or building when right clicking.
/// </summary>
public class UserControl : MonoBehaviour
{
    public Camera GameCamera;
    public float PanSpeed = 10.0f;
    public GameObject Marker;
    public Text _objectText;
    public Text _descriptionText;

    private Worker _worker = null;
    private Resource _resource = null;

    

    private void Start()
    {
        Marker.SetActive(false);
        _objectText.text = "";
        _descriptionText.text = "";
    }

    public void HandleSelection()
    {
        _worker = null;
        _resource = null;
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            
            _worker = hit.collider.GetComponentInParent<Worker>();
            _resource= hit.collider.GetComponentInParent<Resource>();


            //check if the hit object have a IUIInfoContent to display in the UI
            //if there is none, this will be null, so this will hid the panel if it was displayed
            //var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
            //UIMainScene.Instance.SetNewInfoContent(uiInfo);
        }

        if (_worker!=null)
        {
            _objectText.text = _worker._name;
            _descriptionText.text = _worker._description;
        }
        else if (_resource != null)
        {
            _objectText.text = _resource._name;
            _descriptionText.text = _resource._description;
        }
        else
        {
            _objectText.text = "";
            _descriptionText.text = "";
        }
    }

    public void HandleAction()
    {
        //right click give order to the unit
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (_worker != null)
            {
                var resource = hit.collider.GetComponentInParent<Resource>();

                if (resource != null)
                {
                    _worker.Walk(resource);
                }
                else
                {
                    _worker.Walk(hit.point);
                }
            }
            
            
        }
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GameCamera.transform.position = GameCamera.transform.position + new Vector3(move.y, 0, -move.x) * PanSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HandleAction();
        }

        MarkerHandling();
    }

    // Handle displaying the marker above the unit that is currently selected (or hiding it if no unit is selected)
    void MarkerHandling()
    {
        if (_worker == null && _resource==null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (_worker != null || _resource!=null) //&& Marker.transform.parent != m_Selected.transform)
        {
            Marker.SetActive(true);
            if (_worker != null)
            {
                Marker.transform.SetParent(_worker.transform, true);
            }else if (_resource != null)
            {
                Marker.transform.SetParent(_resource.transform, true);
            }
            
            Marker.transform.localPosition = Vector3.zero;
        }
    }
}
