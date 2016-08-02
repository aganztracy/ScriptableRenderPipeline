using UnityEditor.Graphing;
using UnityEditor.Graphing.Drawing;
using UnityEngine;
using UnityEngine.Graphing;
using UnityEngine.MaterialGraph;

namespace UnityEditor.MaterialGraph
{
    [CustomNodeUI(typeof(Vector3Node))]
    public class Vector3NodeUI : ICustomNodeUi
    {
        private Vector3Node m_Node;

        public float GetNodeUiHeight(float width)
        {
            return 2 * EditorGUIUtility.singleLineHeight;
        }

        public GUIModificationType Render(Rect area)
        {
            if (m_Node == null)
                return GUIModificationType.None;

            EditorGUI.BeginChangeCheck();
            m_Node.value = EditorGUI.Vector3Field(new Rect(area.x, area.y, area.width, EditorGUIUtility.singleLineHeight), "Value", m_Node.value);
            if (EditorGUI.EndChangeCheck())
            {
                //TODO:tidy this shit.
                //EditorUtility.SetDirty(materialGraphOwner.owner);
                return GUIModificationType.Repaint;
            }
            return GUIModificationType.None;
        }

        public INode node
        {
            get { return m_Node; }
            set
            {
                var materialNode = value as Vector3Node;
                if (materialNode != null)
                    m_Node = materialNode;
            }
        }

        public float GetNodeWidth()
        {
            return 200;
        }
    }
}
