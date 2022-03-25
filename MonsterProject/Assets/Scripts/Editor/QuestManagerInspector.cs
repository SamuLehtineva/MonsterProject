using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GA.MonsterProject;

namespace GA.MonsterProject.CustomEditor
{
    [UnityEditor.CustomEditor(typeof(QuestManager))]
    public class QuestManagerInspector : Editor
    {
        private QuestManager m_gcQuestManager;

        private void OnEnable()
        {
            m_gcQuestManager = target as QuestManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Add quest"))
            {
                int iChildCount = m_gcQuestManager.transform.childCount;
                string sName = "Quest" + iChildCount;
                GameObject goQuestObject = new GameObject(sName);

                QuestInfo gcQuestInfo = goQuestObject.AddComponent<QuestInfo>();
                gcQuestInfo.m_sName = sName;

                goQuestObject.transform.parent = m_gcQuestManager.transform;

                m_gcQuestManager.OnValidate();
                Selection.activeGameObject = goQuestObject;
            }
        }
    }
}