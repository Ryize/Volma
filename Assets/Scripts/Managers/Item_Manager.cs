using System.Collections.Generic;

public class Item_Manager : Managers
{
    /*
     * Класс менеджера предметов
     *
     * Реализует логику уведомления о событиях.
     */
    
    // Словарь подписок на события
    private Dictionary<string, List<Base>> _observers = new Dictionary<string, List<Base>>();
    
    /*
     * Метод уведомления о падении
     *
     * Уведовляет всех подписчкиков о событии падения кубика
     * 
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_Fall()
    {
        Notify("falled");
    }
    
    /*
     * Метод уведомления о завершении квеста
     *
     * Уведовляет всех подписчкиков о событии завершения квеста
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_DirtQuestComplete()
    {
        Notify("dirt_completed");
    }
    
    /*
     * Метод уведомления о завершении квеста
     *
     * Уведовляет всех подписчкиков о событии завершения квеста
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_BucketQuestComplete()
    {
        Notify("bucket_completed");
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
        Notify("dirtsLefted");
    }
    
    /*
     * Метод уведомления о завершении зоны ПГП
     *
     * Уведовляет всех подписчкиков о событии завершении зоны ПГП
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_PGP_Zone_Quest()
    {
        Notify("pgp_zone_completed");
    }
    
    /*
     * Метод уведомления о завершении квеста ПГП
     *
     * Уведовляет всех подписчкиков о событии завершении квеста ПГП
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify_PGP_Quest()
    {
        Notify("pgp_completed");
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
    public void Subscribe(string subscribeType, Base obj){
        if (!_observers.ContainsKey(subscribeType))
        {
            _observers.Add(subscribeType, new List<Base> {obj});
        }
        else
        {
            _observers[subscribeType].Add(obj);
        }
    }
    
    /*
     * Метод отподписки
     *
     * Реализует механизм отподписки
     *
     * Args:
     *  subscribeType: string (тип подписки)
     */
    public void Unsubscribe(string subscribeType){
        _observers.Remove(subscribeType);
    }
    
    /*
     * Метод уведомления
     *
     * Уведовляет всех подписчкиков о событии
     *
     * Args:
     *  status: bool (статус квеста)
     */
    public void Notify(string subscribeType)
    {
        foreach (var observers in _observers)
        {
            if (observers.Key == subscribeType)
            {
                foreach (var observer in observers.Value)
                {
                    observer.Notify(subscribeType);
                }
            }
        }
    }
}
