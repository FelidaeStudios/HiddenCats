using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Changes object sprites from outline to filled in when clicked.
    private SpriteRenderer spriteRenderer;
    public Sprite filledSprite;
    public bool isFound;
    public string objectName;

    private GameManager gameManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked: " + gameObject.name);
        // Check that object tag is accurate, change sprite to filled in sprite, update GameManager to reflect found object in list of objects.
        if (gameObject.CompareTag("Object"))
        {
            OnObjectFound();
            Debug.Log("Object status: " + isFound);
            // Update GameManager list of objects.
        }
    }

    public void OnObjectFound()
    {
        if (isFound)
            {
                return;
            }

            if (!isFound)
            {
                spriteRenderer.sprite = filledSprite;
                isFound = true;
                gameManager.MarkObjectAsFound(objectName);
            }
    }
}
