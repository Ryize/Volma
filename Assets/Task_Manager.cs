using UnityEngine;

public class Task_Manager : MonoBehaviour
{
    public Task[] tasks; // список квестов
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
