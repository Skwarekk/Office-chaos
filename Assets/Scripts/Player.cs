using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private void Update()
    {
        float movementValue = GameInput.Instance.GetMovementValue();
        Vector3 movement = new Vector3(movementValue, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
