using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TroopsController : MonoBehaviour
{
    //unsigned int, we don't want any negative numbers
    private int _numberOfTroops = 0;
    private List<Troop> _troopsCollection = new List<Troop>();

    private Rect boundingVolume = new Rect(0f, 0f, 1f, 1f);

    [Tooltip("Bounds from the center of the world to the edges, Note that the height in inimportant")]
    public float MaxBoundsHorizontally;
    [Tooltip("Possible positions of every troop in order.")]
    [SerializeField] private List<Vector3> preDeterminedPositions = new List<Vector3>();
    [SerializeField] private Troop _troopPrefab;

    private Vector3 worldSpaceIntersectionPoint = Vector3.zero;

    #if UNITY_EDITOR
    //Debug Purposes only.
    Vector3 debugintersectionpoint;
    #endif
    public static TroopsController troopsController = null; 
    private void Start(){
        if(!troopsController){
            troopsController = this;
        }
        else {
            Debug.LogError("CAN'T HAVE MORE THAN ONE TROOPCONTROLLER");
        }

        _troopsCollection.Add(Instantiate(_troopPrefab, this.transform, false));
        _troopsCollection[_numberOfTroops].transform.localPosition = preDeterminedPositions[_numberOfTroops++];
        _troopsCollection.Add(Instantiate(_troopPrefab, this.transform, false));
        _troopsCollection[_numberOfTroops].transform.localPosition = preDeterminedPositions[_numberOfTroops++];
        _troopsCollection.Add(Instantiate(_troopPrefab, this.transform, false));
        _troopsCollection[_numberOfTroops].transform.localPosition = preDeterminedPositions[_numberOfTroops++];
    } 

    void Update()
    {
        Ray screenToCursorRay = HelperFunctions.GetMainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        
        if(plane.Raycast(screenToCursorRay, out float distance) && Input.GetMouseButton(1))
            worldSpaceIntersectionPoint = transform.position + screenToCursorRay.direction*distance;
        

        worldSpaceIntersectionPoint = new Vector3(
        ClampValueInTheBoundingVolume(worldSpaceIntersectionPoint.x), //clamp x
        worldSpaceIntersectionPoint.y,
        worldSpaceIntersectionPoint.z 
        );
        #if UNITY_EDITOR
            debugintersectionpoint = worldSpaceIntersectionPoint;
        #endif
        float difference = worldSpaceIntersectionPoint.x - transform.position.x;
        float Speed = MathUtilities.Remap(0.0f, 3f, 0.0f, 1.0f, Mathf.Abs(difference));

        if(Speed < 0.1f) Speed = 0f;
        
        foreach(var troop in _troopsCollection){
            troop.NotifyTroops(Speed * Mathf.Sign(difference));

        }

        transform.position = new Vector3(
        Mathf.MoveTowards(transform.position.x, worldSpaceIntersectionPoint.x, 7f * Speed * Time.deltaTime), 
        transform.position.y, 
        transform.position.z
        );
        transform.position = new Vector3(
        ClampValueInTheBoundingVolume(transform.position.x), 
        transform.position.y, 
        transform.position.z);

    }

    float ClampValueInTheBoundingVolume(float v){
        return Mathf.Clamp(v, -MaxBoundsHorizontally + boundingVolume.width / 2f, MaxBoundsHorizontally - boundingVolume.width / 2f);
    }

    void UpdateBoundingVolume(){
        float maxWidth = 0.5f;
        float maxHeight = 0.5f;
        foreach(var troop in _troopsCollection){
            maxWidth = Mathf.Max(maxWidth, Mathf.Abs(troop.transform.localPosition.x));
            maxHeight = Mathf.Max(maxHeight, Mathf.Abs(troop.transform.localPosition.z));
        }
        //multiply by 2 because the "the distance to each edge" starts from the center
        boundingVolume = new Rect(0f, 0f, maxWidth * 2, maxHeight * 2);
    }
    #if UNITY_EDITOR
    void OnDrawGizmos(){
        UpdateBoundingVolume();
        Gizmos.color = Color.white;
        //performs gizmos draws in the object's space
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.up, new Vector3(boundingVolume.width, 2f, boundingVolume.height));
        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        foreach(var pos in preDeterminedPositions){
            Gizmos.DrawSphere(pos, 0.3f);
        }
        Rect GetMaxBounds() {
            float maxWidth = 1f;
            float maxHeight = 1f;
            foreach(var pos in preDeterminedPositions){
                maxWidth = Mathf.Max(maxWidth, Mathf.Abs(pos.x));
                maxHeight = Mathf.Max(maxHeight, Mathf.Abs(pos.z));
            }
            //multiply by 2 because the "the distance to each edge" starts from the center
            return new Rect(0f, 0f, maxWidth * 2, maxHeight * 2);
        }
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireCube(Vector3.up, new Vector3(GetMaxBounds().width, 2f, GetMaxBounds().height));

        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(0f, 1f, transform.position.z), new Vector3(MaxBoundsHorizontally * 2, 2f, 2f));
        
        Gizmos.DrawSphere(debugintersectionpoint, 0.3f);
    }
    #endif
}
