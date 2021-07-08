using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(AnimationController))]
public class AnimationControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AnimationController animationController = (AnimationController)target;
        if (GUILayout.Button("Set Speed"))
        {
            animationController.SetSpeed();
        }
    }
}
