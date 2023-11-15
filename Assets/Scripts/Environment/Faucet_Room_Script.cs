using UnityEngine;

public class Faucet_Room_Script : Base
{
    /*
     * Скрипт для набирания воды в ведро
     *
     * При набирании воды выключает пустое ведро, и включает ведро с водой
    */
    //public Bucket_In_Area_Quest_Script bucketInArea;
    
    // Объект ведра
    public GameObject bucket;
    
    // Сколько осталось набрать воды
    public float bucketFillAmount;
    //private ParticleSystem.Trails waterTrails;
    void Notify(string type, bool status)
    {
        /*
         * Метод уведомления о событии
         *
         * Отслеживается событие bucketInArea.
         * И в зависимости от успешности проверок ведро набирается 
        */
        /*// напор воды
        var trailsData = new ParticleSystem.Trails(true);
        trailsData.
        waterTrails.ratio = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad); 
        //water.emission = _emissionModule;
        water.SetEmissionRateOverTime(_emissionModule.rateOverTime);
        //water.SetEmissionRateOverTime(_emissionModule)
        water.set*/
        
        // Если событие не установка ведра, выходим из метода
        if (type != "bucketInArea")
        {
            return;
        }
        GameObject empty = bucket.transform.GetChild(bucket.transform.childCount - 1).gameObject;
        
        // Если поставлено не пустое ведро
        if (!empty.activeSelf)
        {
            return;
        }

        // сила напора
        bucketFillAmount -= Mathf.Sin(transform.eulerAngles.y) * Time.deltaTime;
        
        // Если ведро заполнено
        if (bucketFillAmount < 0.1)
        {
            bucket.transform.GetChild(1).gameObject.SetActive(true);
            empty.SetActive(false);
        }
    }
}
