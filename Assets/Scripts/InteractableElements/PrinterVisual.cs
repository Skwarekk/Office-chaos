using UnityEngine;

public class PrinterVisual : MonoBehaviour
{
    private const string PRINT = "Print";

    [SerializeField] private Printer printer;
    [SerializeField] private Transform papersOnTheFloorPoint;
    [SerializeField] private Transform papersOnTheFloorPrefab;
    private Animator animator;

    private void Start()
    {
        printer.OnInteract += Papers_OnInteract;
        animator = GetComponent<Animator>();
    }

    private void Papers_OnInteract(object sender, System.EventArgs e)
    {
        animator.SetTrigger(PRINT);
        Instantiate(papersOnTheFloorPrefab, papersOnTheFloorPoint);
    }
}
