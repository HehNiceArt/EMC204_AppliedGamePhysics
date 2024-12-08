using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;
    public static PlayerPersistence Instance { get { return instance; } }
    const string PlayerPositionKey = "PlayerPosition";
    [SerializeField] Vector3 spawnPoint;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        LoadPlayerPosition();
        DontDestroyOnLoad(gameObject);
    }
    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat(PlayerPositionKey + "_x", spawnPoint.x);
        float y = PlayerPrefs.GetFloat(PlayerPositionKey + "_y", spawnPoint.y);
        float z = PlayerPrefs.GetFloat(PlayerPositionKey + "_z", spawnPoint.z);
        transform.position = new Vector3(x, y, z);
    }
}