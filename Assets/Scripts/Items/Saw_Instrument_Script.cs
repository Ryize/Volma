using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using BLINDED_AM_ME.Extensions;

public class Saw_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт пилы.
     *
     * Позволяет разрезать объекты (ПГП) пополам.
    */
    
    // Скорость пилы
    private Rigidbody sawRigidbody;
    
    // Начальная прочность объекта
    private CounterTracker pgpCounterTracker;
    
    // Материал разрезанного объекта
    [SerializeField] private Material CapMaterial;
    
    private CancellationTokenSource _previousTaskCancel;

    private void Start()
    {
        sawRigidbody = transform.parent.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при касании пилы с объектом.
         *
         * Отслеживается именно ПГП, тк только он может разрезаться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        
        if (other.name.ToLower().Contains("pgp_item"))
        {
	        Transform pgp = other.transform;
	        pgpCounterTracker = pgp.GetComponent<CounterTracker>();

	        float velocity = Mathf.Clamp01(sawRigidbody.velocity.magnitude * 0.5f);
        
	        if ((pgpCounterTracker.tracker -= velocity) <= 0)
	        {
		        //var timeLimit = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
	        
		        //Cut(other.gameObject, timeLimit);
	        
		        Cut(other.gameObject);
	        }
        }

        if (other.name.ToLower().Contains("cut collider"))
        {
	        Transform cutLine = other.transform.GetChild(0);
	        cutLine.GetComponent<MeshRenderer>().enabled = true;

	        Vector3 position = new Vector3(0, other.transform.InverseTransformPoint(transform.position).y, 0);

	        cutLine.localPosition = position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
	    if (other.name.ToLower().Contains("cut collider"))
	    {
		    Transform cutLine = other.transform.GetChild(0);
		    cutLine.GetComponent<MeshRenderer>().enabled = false;
	    }
    }

    private void Cut(GameObject target, CancellationToken cancellationToken = default)
		{
			try
			{
				_previousTaskCancel?.Cancel();
				_previousTaskCancel = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
				cancellationToken = _previousTaskCancel.Token;
				cancellationToken.ThrowIfCancellationRequested();

				// get the victims mesh
				var leftSide = target;
				var leftMeshFilter = leftSide.GetComponent<MeshFilter>();
				var leftMeshRenderer = leftSide.GetComponent<MeshRenderer>();

				var rightSide = Instantiate(target);
				var rightMeshFilter = rightSide.GetComponent<MeshFilter>();
				var rightMeshRenderer = rightSide.GetComponent<MeshRenderer>();

				var materials = new List<Material>();
				leftMeshRenderer.GetSharedMaterials(materials);

				// the insides
				var capSubmeshIndex = 0;
				if (materials.Contains(CapMaterial))
					capSubmeshIndex = materials.IndexOf(CapMaterial);
				else
				{
					capSubmeshIndex = materials.Count;
					materials.Add(CapMaterial);
				}

				// set the blade relative to victim
				var blade = new Plane(
					Vector3.up,
					leftSide.transform.InverseTransformPoint(transform.position));
				
				// разрез ровно посередине
				/*var blade = new Plane(
					Vector3.up,
					leftSide.transform.localPosition);*/

				Debug.Log("blade: " + blade);

				var mesh = leftMeshFilter.sharedMesh;
				//var mesh = leftMeshFilter.mesh;

				// Cut
				var pieces = mesh.Cut(blade, capSubmeshIndex, cancellationToken);

				leftSide.name = "LeftSide";
				leftMeshFilter.mesh = pieces.Item1;
				leftMeshRenderer.sharedMaterials = materials.ToArray();
				//leftMeshRenderer.materials = materials.ToArray();

				rightSide.transform.SetPositionAndRotation(leftSide.transform.position, leftSide.transform.rotation);
				rightSide.transform.localScale = leftSide.transform.localScale;

				rightSide.name = "RightSide";
				rightMeshFilter.mesh = pieces.Item2;
				rightMeshRenderer.sharedMaterials = materials.ToArray();
				//rightMeshRenderer.materials = materials.ToArray();

				// Physics 
				Destroy(leftSide.GetComponent<Collider>());
				Destroy(rightSide.GetComponent<Collider>());

				// Replace
				var leftCollider = leftSide.AddComponent<MeshCollider>();
				leftCollider.convex = true;
				leftCollider.sharedMesh = pieces.Item1;

				var rightCollider = rightSide.AddComponent<MeshCollider>();
				rightCollider.convex = true;
				rightCollider.sharedMesh = pieces.Item2;

				// rigidbody
				if (!leftSide.GetComponent<Rigidbody>())
					leftSide.AddComponent<Rigidbody>();

				if (!rightSide.GetComponent<Rigidbody>())
					rightSide.AddComponent<Rigidbody>();

				rightSide.GetComponent<Rigidbody>().useGravity = true;
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
			}
		}
}
