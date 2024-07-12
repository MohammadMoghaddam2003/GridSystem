#if UNITY_EDITOR

using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace Grid_System
{
    [CustomEditor(typeof(GridGenerator))]
    public class GridGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GridGenerator gridGenerator = (GridGenerator) target;
            
            GUILayout.Space(20);

            if (GUILayout.Button("Generate 2D"))
            {
                MethodInfo generate =
                    typeof(GridGenerator).GetMethod("Generate 2D", BindingFlags.NonPublic | BindingFlags.Instance);
                if (generate != null)
                {
                    generate.Invoke(gridGenerator, null);
                }
            }
            
            GUILayout.Space(2);

            if (GUILayout.Button("Generate 3D"))
            {
                MethodInfo generate =
                    typeof(GridGenerator).GetMethod("Generate 3D", BindingFlags.NonPublic | BindingFlags.Instance);
                if (generate != null)
                {
                    generate.Invoke(gridGenerator, null);
                }
            }
        }
    }    
}

#endif

