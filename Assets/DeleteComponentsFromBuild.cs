#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteComponentsFromBuild : MonoBehaviour, IProcessSceneWithReport
{
    [SerializeField]
    private List<Component> _componentsToDelete = new List<Component>();

    public int callbackOrder { get { return 0; } }

    public void OnProcessScene(Scene scene, BuildReport report)
    {
        foreach (Component componentToDelete in _componentsToDelete)
            DestroyImmediate(componentToDelete);

        DestroyImmediate(this);
    }
}
#endif
