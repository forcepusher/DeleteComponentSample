#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteComponentsFromBuild : IProcessSceneWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnProcessScene(Scene scene, BuildReport report)
    {
        foreach (GameObject rootGameObject in scene.GetRootGameObjects())
        {
            DeleteComponents(rootGameObject.transform, "ExtremelyUselessComponent");
            DeleteComponents(rootGameObject.transform, "AnotherUselessComponentThatMightNotExist");
            DeleteComponents(rootGameObject.transform, "TweakThisListOfComponentsInCodeDirectly");
        }

        Object[] deletionComponents = Resources.FindObjectsOfTypeAll(typeof(DeleteSpecificComponentsFromBuild));
        foreach (DeleteSpecificComponentsFromBuild deletionComponent in deletionComponents)
            deletionComponent.DeleteComponents();
    }

    private void DeleteComponents(Transform transform, string componentName)
    {
        var uselessComponent = transform.GetComponent(componentName);
        if (uselessComponent != null)
            Object.DestroyImmediate(uselessComponent);

        foreach (Transform childTransform in transform)
            DeleteComponents(childTransform, componentName);
    }
}
#endif
