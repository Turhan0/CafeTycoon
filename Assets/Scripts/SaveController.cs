using UnityEngine;
using System.IO;
using Unity.Cinemachine;
public class SaveController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string saveLocation;
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        LoadGame();
    }

    public void SaveGame(SaveData data)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CinemachineConfiner confiner = GameObject.FindObjectOfType<CinemachineConfiner>();
        
        if (player != null && confiner != null)
        {
            SaveData saveData = new SaveData
            {
                playerPosition = player.transform.position,
                mapBoundary = confiner.m_BoundingShape2D.gameObject.name
            };
            File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
        }
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                player.transform.position = saveData.playerPosition;

            CinemachineConfiner confiner = GameObject.FindObjectOfType<CinemachineConfiner>();
            GameObject boundaryObject = GameObject.Find(saveData.mapBoundary);
            if (confiner != null && boundaryObject != null)
                confiner.m_BoundingShape2D = boundaryObject.GetComponent<PolygonCollider2D>();
        }
        else
        {
            SaveGame(new SaveData());
        }
    }
}
