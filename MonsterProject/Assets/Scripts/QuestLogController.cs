using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class QuestLogController : MonoBehaviour
    {
        public GameObject m_goTemplate;
        private QuestInfo[] m_aActveQuests;

        public void UpdateQuestLog()
        {
            GameObject[] aThings = GameObject.FindGameObjectsWithTag("LogEntry");
            foreach (GameObject thing in aThings)
            {
                Destroy(thing);
            }
            m_aActveQuests = UIManager.s_UIManager.m_gcQuestManager.GetActiveQuests();

            for (int i = 0; i < m_aActveQuests.Length; i++)
            {
                var item = Instantiate(m_goTemplate, transform);
                item.GetComponentInChildren<TMP_Text>().text = m_aActveQuests[i].m_sDescription;

                Vector3 position = m_goTemplate.GetComponent<RectTransform>().anchoredPosition;
                position.y = -i * 100;
                item.GetComponent<RectTransform>().anchoredPosition = position;
                item.gameObject.SetActive(true);
                if (m_aActveQuests[i].m_iStatus == Types.EStatus._Active)
                {
                    item.transform.Find("Tick").gameObject.SetActive(false);
                }
            }
        }
    }
}
