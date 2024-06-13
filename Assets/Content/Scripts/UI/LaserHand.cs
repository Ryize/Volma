using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserHand : SteamVR_LaserPointer
{
    /*
     * Класс указки
     *
     * Класс рисует указку, с помощью которй можно переключать кнопки меню
     * и телепоритовать предметы к руке
     */

    [SerializeField]
    private Hand hand;

    private Interactable cachedInteractable = null;

    /*
     * Метод входа указки
     *
     * Если указка вошла в объект, то она активируется и меняет цвет кнопки на синий
     * Args:
     *  e: PointerEventArgs (объект, который поймала указка)
     */
    public override void OnPointerIn(PointerEventArgs e)
    {
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color=Color.cyan;
        }

        if (!hand || hand.AttachedObjects.Count > 0)
        {
            return;
        }


        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI") || e.target.tag.ToLower().Contains("item"))
        {
            pointer.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (previousContact && previousContact.tag.ToLower().Contains("item"))
        {
            if (!cachedInteractable || cachedInteractable.transform != previousContact)
            {
                cachedInteractable = previousContact.GetComponent<Interactable>();
            }

            if (!hand || hand.AttachedObjects.Count > 0)
            {
                return;
            }

            if (cachedInteractable)
            {
                hand.hoveringInteractable = cachedInteractable;
            }
        }
    }

    /*
     * Метод отработки нажатия на кнопку
     *
     * Если указка указывает на кнопку, то она на неё нажимает
     * Если указка указывает на Item, то она телепортирует его к руке
     * 
     * Args:
     *  e: PointerEventArgs (объект, который поймала указка)
     */
    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);
        
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }

        if (e.target.tag.ToLower().Contains("item"))
        {
            //e.target.position = transform.position;
        }
    }

    /*
     * Метод выхода указки
     *
     * Если указка вышла из объекта, то она деактивируется и меняет цвет кнопки на белый
     * Args:
     *  e: PointerEventArgs (объект, который поймала указка)
     */
    public override void OnPointerOut(PointerEventArgs e)
    {
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color=Color.white;
        }
        
        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI") || e.target.tag.ToLower().Contains("item"))
        {
            pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}