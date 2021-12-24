using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;

public class ObjectAutoPlacement : MonoBehaviour
{
    [SerializeField] GameObject placedObject;
    [SerializeField] private ARPlaneManager arPM;

    private GameObject goPlanet = null;

    private void Awake()
    {
        arPM = GetComponent<ARPlaneManager>();
        arPM.planesChanged += PlaneChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && goPlanet == null)
        {
            ARPlane arPlane = args.added[0];
            goPlanet = Instantiate(placedObject, arPlane.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
