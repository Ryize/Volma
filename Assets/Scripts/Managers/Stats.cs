using System.Collections.Generic;
using System.Linq;

public class Stats : Repository
{
    /*
     * Класс статистики.
     *
     * Сохраняет статистику по использованию цемента, воды.
    */
    
    // Кол-во цемента в статистике
    private float _cement = 0f;
    
    // Кол-во воды в статистике
    private float _water = 0f;
    
    // Тире в качестве разделителя
    private string dash = "------------------------------------";

    // Доска на которой выводится статистика
    public TextChange_Script text;
    
    public float cement
    {
        get
        {
            return _cement;
        }
        set
        {
            /*
             * При изменении кол-ва цемента сразу меняем и данные в статистике.
             *
             * Цемент должен идти с кг и разделятся тире (переменная dash).
            */
            _cement = value;
            
            List<string> statsEl = text.currentText.text.Split(dash).ToList();
            List<string> cementList = statsEl[0].Replace("кг", "").Split(" ").ToList();
            text.currentText.text = cementList[0] + " " + _cement + "кг" + "\n" + dash + statsEl[1];
        }
    }
}
