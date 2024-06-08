using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using BLINDED_AM_ME.Extensions;

public class PGP_Item_Script : MonoBehaviour
{
    [SerializeField] private CounterTracker pgpStrength;
    [SerializeField] private PgpStatus status;
    [SerializeField] private Rigidbody pgpRigidbody;
    [SerializeField] private PositionKeeper pgpPositionKeeper;

    [Header("Cut Line")]
    [SerializeField] private Collider cutCollider; 
    [SerializeField] private Renderer curLineRenderer;
    
    [Header("Materials")]
    [SerializeField] private Material pgpMaterial;
    [SerializeField] private Material greenQuestMaterial;
    [SerializeField] private Material redQuestMaterial;
    
    private CancellationTokenSource _previousTaskCancel;
    private Timer timer;

    private enum PgpStatus
    {
	    larger,
	    smaller,
	    fiting,
	    garbage
    }
    
    private void Awake()
    {
	    pgpStrength.tracker = 100;
	    name = "pgp_item";
	    pgpRigidbody.useGravity = true;
	    curLineRenderer.enabled = false;
	    pgpPositionKeeper.TpToDefaultPosition();
    }

    public void SetCutLineVisibility(bool isVisible)
    {
	    curLineRenderer.enabled = isVisible;
    }

    public void ChangeCutLineColor(bool isValid)
    {
	    curLineRenderer.material = isValid ? greenQuestMaterial : redQuestMaterial;
    }

    public void MoveCutLine(float position)
    {
	    curLineRenderer.transform.localPosition = new Vector3(0, position, 0);
    }

    public void Hit(float velocity)
    {
	    if (!((pgpStrength.tracker -= velocity) <= 0.01f)) return;
	    
	    Transform cutLine = curLineRenderer.transform;
	    bool isHalf = Mathf.Abs(cutLine.localPosition.y) < 0.2;

	    Instantiate(transform);
		        
	    Cut(gameObject, isHalf);
    }
    
    /*
     * Метод разреза объекта
     *
     * Крайне не рекомедуется трогать этот метод, т.к. он взят из инета
     *
     * Args:
     *	target: GameObject (объект для разреза)
     *	isHalf: bool (если нужно порузать половину)
     *	cancellationToken: CancellationToken (хз, лучше не трогать)
     */
    private void Cut(GameObject target, bool isHalf = false, CancellationToken cancellationToken = default)
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
				if (materials.Contains(pgpMaterial))
					capSubmeshIndex = materials.IndexOf(pgpMaterial);
				else
				{
					capSubmeshIndex = materials.Count;
					materials.Add(pgpMaterial);
				}

				Vector3 bladePoint;
				
				if (isHalf)
				{
					// Разрез ровно посередине
					bladePoint = leftSide.transform.localPosition;
				}
				else
				{
					// Разрез там, где пила
					bladePoint = leftSide.transform.InverseTransformPoint(curLineRenderer.transform.localPosition);
				}
				
				var blade = new Plane(Vector3.up, bladePoint);

				Debug.Log("blade: " + blade);

				var mesh = leftMeshFilter.sharedMesh;
				//var mesh = leftMeshFilter.mesh;

				// Cut
				var pieces = mesh.Cut(blade, capSubmeshIndex, cancellationToken);

				string name = target.name;
				
				leftSide.name = "Left_" + name;
				leftMeshFilter.mesh = pieces.Item1;
				leftMeshRenderer.sharedMaterials = materials.ToArray();
				//leftMeshRenderer.materials = materials.ToArray();

				rightSide.transform.SetPositionAndRotation(leftSide.transform.position, leftSide.transform.rotation);
				rightSide.transform.localScale = leftSide.transform.localScale;

				rightSide.name = "Right_" + name;
				rightMeshFilter.mesh = pieces.Item2;
				rightMeshRenderer.sharedMaterials = materials.ToArray();
				//rightMeshRenderer.materials = materials.ToArray();
				
				if (!isHalf)
				{
					leftSide.name = "Trash_" + leftSide.name;
					rightSide.name = "Trash_" + rightSide.name;
				}

				// Physics 
				Destroy(leftSide.GetComponent<Collider>());
				Destroy(rightSide.GetComponent<Collider>());
				
				Destroy( leftSide.transform.GetChild(0).gameObject);
				Destroy(rightSide.transform.GetChild(0).gameObject);

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
