using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Changes object sprites from outline to filled in when clicked.
    private SpriteRenderer spriteRenderer;
    public Sprite hiddenSprite;
    public Sprite foundSprite;
    public bool isFound;
    public string objectName;

    private GameManager gameManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindFirstObjectByType<GameManager>();
        objectName = gameObject.name; // Set the objectName to the name of the GameObject.
    }

    private void OnMouseDown()
    {
        //Debug.Log("Object clicked: " + gameObject.name);
        // Check that object tag is accurate, change sprite to filled in sprite, update GameManager to reflect found object in list of objects.
        if (gameObject.CompareTag("Object"))
        {
            OnObjectFound();
            //Debug.Log("Object status: " + isFound);
        }
    }

    public void OnObjectFound()
    {
        if (isFound)
            {
                Debug.Log("Object already found: " + objectName);
                return;
            }

            if (!isFound)
            {
                Debug.Log("Object found: " + objectName);
                spriteRenderer.color = Color.magenta; // Remove once all foundSprite objects are finished
                //spriteRenderer.sprite = foundSprite;
                isFound = true;
                gameManager.MarkObjectAsFound(objectName);
            }
    }
}
