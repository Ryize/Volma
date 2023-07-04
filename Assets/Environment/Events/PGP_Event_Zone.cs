using UnityEngine;

public class PGP_Event_Zone : MonoBehaviour
{
    private bool questStatus = false;

    public void CompleteQuest()
    {
        questStatus = true;
    }

    public bool GetQuestStatus()
    {
        return questStatus;
    }
}
