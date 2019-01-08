using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class FoodImageAnchor : MonoBehaviour
{
    [SerializeField]
    private ARReferenceImage referenceImage;

    [SerializeField]
    private GameObject foodDisplayer;

    private void Start()
    {
        UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
        UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpdateImageAnchor;
        UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;
    }

    private void AddImageAnchor(ARImageAnchor arImageAnchor)
    {
        Debug.LogFormat("image anchor added[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        if (arImageAnchor.referenceImageName == referenceImage.imageName)
        {
            Vector3 position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
            Quaternion rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);

            foodDisplayer.transform.position = position;
            foodDisplayer.transform.rotation = rotation;
            foodDisplayer.GetComponent<FoodDisplayer>().IsInitialized = true;
        }
    }

    private void UpdateImageAnchor(ARImageAnchor arImageAnchor)
    {
        Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        if (arImageAnchor.referenceImageName == referenceImage.imageName)
        {
            if (arImageAnchor.isTracked)
            {
                if (!foodDisplayer.activeSelf)
                {
                    foodDisplayer.SetActive(true);
                }
                foodDisplayer.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                foodDisplayer.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);
            }
            else if (foodDisplayer.activeSelf)
            {
                foodDisplayer.SetActive(false);
            }
        }
    }

    private void RemoveImageAnchor(ARImageAnchor arImageAnchor)
    {
        Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        if (foodDisplayer)
        {
            Destroy(foodDisplayer);
        }
    }

    private void OnDestroy()
    {
        UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
        UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpdateImageAnchor;
        UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;
    }
}
