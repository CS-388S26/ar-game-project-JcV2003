using UnityEngine;
using Vuforia;

public class CorePlacement : MonoBehaviour
{
    public GameObject corePrefab;
    public GameObject planeFinder;
    public GameObject gameManager;

    public void PlaceCore(HitTestResult result)
    {
        //GameObject core = Instantiate(corePrefab, result.Position, result.Rotation);

        //planeFinder.SetActive(false);

        //gameManager.GetComponent<GameManager>().corePlaced(core);
    }
}