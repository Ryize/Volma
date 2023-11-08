public class Spacer_Instrument_Script : PGP_Zone_Quest_Script
{
    /*
     * Класс распорки над дверным проёмом (при ПГП квесте)
    */
    
    // Установлена ли распорка
    public bool done = false;

    public bool isDone()
    {
        /*
         * Возвращает статус распорки.
         *
         * Returns:
         *  bool: true - распорка установлена, false - нет
        */
        return done;
    }

    public void setDone() {
        /*
         * Устанавливает статус распорки, как установлено (true)
        */
        done = true;
    }
}
