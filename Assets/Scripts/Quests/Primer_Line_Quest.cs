using System;
using UnityEngine;

public class Primer_Line_Quest: Quest
{
    /*
     * Класс отвечающий за логику нанесения грунтовки
     */
    
    // Компонент Renderer для грунтовки
    private Renderer primerRenderer;
    
    // Компонент Renderer для зоны грунтовки
    private Renderer primerZoneRenderer;
    
    // Прозрачность
    private float _opacity;
    
    // Готова ли грунтовка
    private bool _isDone;

    public Item_Repository repository;

    private void Start()
    {
        primerRenderer = GetComponent<Renderer>();
        primerZoneRenderer = transform.GetChild(0).GetComponent<Renderer>();
        
        _opacity = 0f;
        ChangeObjectOpacity(_opacity);

        primerRenderer.enabled = false;
        
        _isDone = false;
    }

    /*
     * Метод нанесения грунтовки
     *
     * Увеличивает прозрачность грунтовки на 0.1
     */
    public void ApplyPrimer()
    {
        if (_opacity < 0.001f)
        {
            primerRenderer.enabled = true;
            primerZoneRenderer.enabled = false;
        }
        
        ChangeObjectOpacity(_opacity += 0.01f);
        
        if (Math.Abs(_opacity - 1f) < 0.001f)
        {
            _isDone = true;
            repository.PrimerAmount--;
        }
    }

    public bool isDone
    {
        get
        {
            return _isDone;
        }
    }

    /*
     * Метод меняющий прозрачность объекта
     *
     * Получает на вход число от 0 до 1 и меняет прозрачность рендера
     *
     * Args:
     *  opacity: float (прозрачность)
     */
    private void ChangeObjectOpacity(float opacity)
    {
        // Держит число в рамках от 0 до 1
        opacity = Mathf.Clamp01(opacity);

        // Применяем новую прозрачность
        Color newColor = primerRenderer.material.color;
        newColor.a = opacity;
        primerRenderer.material.color = newColor;
    }
}