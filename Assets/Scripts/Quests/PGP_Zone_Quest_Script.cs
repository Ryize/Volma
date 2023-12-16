using UnityEngine;

public class PGP_Zone_Quest_Script : MonoBehaviour
{
    private bool questStatus = false;

    public void CompleteQuest()
    {
        questStatus = true;
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    public bool GetQuestStatus()
    {
        return questStatus;
    }
}
