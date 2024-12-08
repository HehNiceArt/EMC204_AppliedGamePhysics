using UnityEngine;

enum itemString
{
    firstItem,
    secondItem,
    thirdItem,
    fourthItem
}
[RequireComponent(typeof(Level))]
public class PrizeCollide : MonoBehaviour
{
    [SerializeField] float colliderRadius;
    SphereCollider sphereCollider;
    Level level;
    [SerializeField] KeyItemSO keyItemSO;
    [SerializeField] itemString itemString;
    private void Start()
    {
        sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = colliderRadius;
        sphereCollider.isTrigger = true;
        level = GetComponent<Level>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CompareItemToLevel();
            level.LoadScene();
        }
    }

    void CompareItemToLevel()
    {
        switch (itemString)
        {
            case itemString.firstItem:
                keyItemSO.firstItem = true;
                Debug.Log("first item get!");
                break;
            case itemString.secondItem:
                keyItemSO.secondItem = true;
                Debug.Log("second item get!");
                break;
            case itemString.thirdItem:
                keyItemSO.thirdItem = true;
                Debug.Log("third item get!");
                break;
            case itemString.fourthItem:
                keyItemSO.fourthItem = true;
                Debug.Log("fourth item get!");
                break;
        }
    }
}
