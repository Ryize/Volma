using UnityEngine;

public class Task_Manager_Script : MonoBehaviour
{
    public Task_Is_Done_Quest_Script[] tasks; // список квестов
    public int currentTask; // текущий квест
    
    void Start()
    {
        currentTask = 0;
    }
    
    void Update()
    {
        // смена квеста в случае завершения
        if (currentTask < tasks.Length && tasks[currentTask].isDone())
            currentTask++;
    }
}
