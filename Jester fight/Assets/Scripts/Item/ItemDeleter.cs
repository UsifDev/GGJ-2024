using UnityEngine;

public class ItemDeleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
