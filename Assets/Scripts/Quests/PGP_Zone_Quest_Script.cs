using UnityEngine;

public class PGP_Zone_Quest_Script : MonoBehaviour
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
