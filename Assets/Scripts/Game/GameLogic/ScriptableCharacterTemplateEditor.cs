using UnityEditor;

namespace Game.GameLogic
{
    [CanEditMultipleObjects, CustomEditor(typeof(ScriptableCharacterTemplate))]
    public class ScriptableCharacterTemplateEditor : Editor
    {
        public void OnEnable()
        {
            
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
