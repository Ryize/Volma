using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за засыпание цемента в ведро с водой.
    */

    // Статистика
    [SerializeField] private Stats stats;

    [SerializeField] private Spillable spillable;

    [SerializeField] private ParticleSystem sandLeak;

    [SerializeField] private AudioSource bagSpillingSound;

    [SerializeField] private Rigidbody bagRigidbody;

    [SerializeField] private float cementCount = 30;
    
    private Bucket_Item_Script cachedBucket = null;

    private void Update()
    {
        Spill();
    }

    private void Spill()
    {
        // Песок должен высыпаться
        if (!spillable || !spillable.IsSpilling)
        {
            sandLeak.maxParticles = 0;
            return;
        }

        sandLeak.maxParticles = 10;

        if (bagSpillingSound != null && !bagSpillingSound.isPlaying) bagSpillingSound.Play();
        else bagSpillingSound.Stop();

        cachedBucket = BucketRaycast();

        if (cementCount > 0)
        {
            float cementSpilling = (bagRigidbody.velocity.magnitude * 5 + 1) * Time.deltaTime;

            stats.cement += cementSpilling;

            if (cachedBucket)
            {
                cachedBucket.sandVolume += cementSpilling;
            }

            cementCount -= cementSpilling;
        }
    }

    private Bucket_Item_Script BucketRaycast()
    {
        Vector3 origin = transform.position;
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