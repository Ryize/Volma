public class Dirt_Quest_Script : Base
{
    // /*
    //  * Класс квеста грязи
    //  *
    //  * Реализует логику квеста грязи.
    //  */
    //
    // // Массив грязи
    // public List<GameObject> dirts;
    //
    // // Репозиторий предеметов
    // public Item_Repository repa;
    //
    // // Статус квеста
    // private bool isComplete = false;
    //
    // // Менеджер объектов
    // public Item_Manager manager;
    //
    // // Тип событий, который отслеживается 
    // public List<string> subTypes;
    //
    //
    //
    // /*
    //  * Стартовый метод
    //  *
    //  * Следит за кол-вом грязи каждую секунду
    //  */
    // private void Start()
    // {
    //     foreach (var type in subTypes)
    //     {
    //         manager.subscribe(type, this);
    //     }
    // }
    //
    // public override void Notify(string a, bool status)
    // {
    //     repa.Dirt_Quest_isComplete = true;
    // }
    //
    // /*
    //  * Метод отслеживания кол-ва грязи
    //  *
    //  * Реализует логику квеста грязи.
    //  */
    // private void DirtsCountCheck()
    // {
    //     // Квест готов
    //     repa.Dirt_Quest_isComplete = true;
    //     
    // }
}
