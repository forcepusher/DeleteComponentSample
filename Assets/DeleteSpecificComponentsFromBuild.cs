#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

public class DeleteSpecificComponentsFromBuild : MonoBehaviour
{
    [SerializeField]
    private List<Component> _componentsToDelete = new List<Component>();

    public void DeleteComponents()
    {
        foreach (Component componentToDelete in _componentsToDelete)
            DestroyImmediate(componentToDelete);

        DestroyImmediate(this);
    }
}
#endif
