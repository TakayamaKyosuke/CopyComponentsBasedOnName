using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyComponentsBasedOnName : MonoBehaviour
{

    [SerializeField] private GameObject original;
    [SerializeField] private GameObject target;

    private Transform[] origins;
    private Transform[] targets;



    // Use this for initialization
    void Start()
    {
        //CopyComponents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CopyComponents()
    {

        if (original != null && target != null)
        {

            origins = original.GetComponentsInChildren<Transform>();
            targets = target.GetComponentsInChildren<Transform>();

        }
        else
        {
            Debug.LogWarning("original or target is null");
            return;
        }


        foreach (Transform ori in origins)
        {

            GameObject result = null;


            foreach (Transform tar in targets)
            {

                if (tar.name == ori.name)
                {
                    result = tar.gameObject;
                    CopySpecialComponents(ori.gameObject, result);
                }

            }

            if (result != null)
            {
                Debug.Log("find" + ori.name);
            }
            else
            {
                Debug.LogError("not find" + ori.name);
            }

        }

    }

    private void CopySpecialComponents(GameObject _sourceGO, GameObject _targetGO)
    {
        foreach (var component in _sourceGO.GetComponents<Component>())
        {
            var componentType = component.GetType();
            if (componentType != typeof(Transform) && componentType != typeof(MeshFilter) && componentType != typeof(MeshRenderer))
            {
                Debug.Log("Found a component of type " + component.GetType());
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(_targetGO);
                Debug.Log("Copied " + component.GetType() + " from " + _sourceGO.name + " to " + _targetGO.name);
            }
        }
    }
}

