using UnityEngine;

public class PapersVisual : MonoBehaviour
{
    [SerializeField] private Papers papers;
    [SerializeField] private Transform papersOnTheFloorPoint;
    [SerializeField] private Transform papersOnTheFloorPrefab;
    [SerializeField] private GameObject papersSelectedVisual;

    private void Start()
    {
        papers.OnInteract += Papers_OnInteract;
    }

    private void Papers_OnInteract(object sender, System.EventArgs e)
    {
        Instantiate(papersOnTheFloorPrefab, papersOnTheFloorPoint);
        gameObject.SetActive(false);
        papersSelectedVisual.SetActive(false);
    }
}
