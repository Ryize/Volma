using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за засыпание цемента в ведро с водой.
    */

    // Статистика
    [SerializeField] private Stats stats;

    [SerializeField] private Spillable spillable;

    [SerializeField] private Rigidbody bagRigidbody;

    [SerializeField] private float cementCount = 30;

    [SerializeField] private Transform leakTransform;
    
    private Bucket_Item_Script cachedBucket = null;

    private void Update()
    {
        Spill();
    }

    private void Spill()
    {
        // Песок должен высыпаться
        if (!spillable.isSpilling) {
            spillable.useEffect = false;
            return;
        }

        cachedBucket = BucketRaycast();

        if (cementCount > 0)
        {
            spillable.useEffect = true;
            
            float cementSpilling = (bagRigidbody.velocity.magnitude * 3 + 3) * Time.deltaTime;

            stats.cement += cementSpilling;

            if (cachedBucket)
            {
                cachedBucket.sandVolume += cementSpilling;
            }

            cementCount -= cementSpilling;
        }
        else
        {
            spillable.useEffect = false;
        }
    }

    private Bucket_Item_Script BucketRaycast()
    {
        Vector3 origin = leakTransform.position;
        Vector3 derection = Vector3.down;

        // Максимальная дистанция для засыпания
        float distance = 10f;

        RaycastHit bucket;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out bucket, distance))
        {
            return null;
        }

        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("water"))
        {
            return null;
        }

        if (cachedBucket && cachedBucket.transform == bucket.transform)
            return cachedBucket;
        
        return bucket.transform.GetComponent<Bucket_Item_Script>();
    }
}