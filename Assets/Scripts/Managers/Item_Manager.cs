using System.Collections.Generic;

public class Item_Manager : Managers
{
    /*
     * Класс менеджера предметов
     *
     * Реализует логику уведомления о событиях.
     */
    
    // Словарь подписок на события
    private Dictionary<string, Base> _observers = new Dictionary<string, Base>();
    
    /*
     * Метод уведомления о падении
     *
     * Уведовляет всех подписчкиков о событии падения кубика
     * 
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_Fall(bool status)
    {
        foreach (var observer in _observers)
        {
            if (observer.Key == "falled")
            {
                observer.Value.Notify("falled", status);
            }
        }
    }
    
    /*
     * Метод уведомления о завершении квеста
     *
     * Уведовляет всех подписчкиков о событии завершения квеста
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_QuestComplete(bool status)
    {
        foreach (var observer in _observers)
        {
            if (observer.Key == "completed")
            {
                observer.Value.Notify("completed", status);
            }
        }
    }
    
    /*
     * Метод уведомления о завершении квеста
     *
     * Уведовляет всех подписчкиков о событии завершения квеста
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_DirtsIsLeft()
    {
        foreach (var observer in _observers)
        {
            if (observer.Key == "dirtsLefted")
            {
                observer.Value.Notify("dirtsLefted", true);
            }
        }
    }
    
    /*
     * Метод подписки
     *
     * Реализует механизм подписки
     *
     * Args:
     *  subscribeType: string (тип подписки)
     *  obj: Base (объект, который подписывается)
     */
    public void subscribe(string subscribeType, Base obj){
        _observers.Add(subscribeType, obj);
    }
    
    /*
     * Метод отподписки
     *
     * Реализует механизм отподписки
     *
     * Args:
     *  subscribeType: string (тип подписки)
     */
    public void unsubscribe(string subscribeType){
        _observers.Remove(subscribeType);
    }
}
