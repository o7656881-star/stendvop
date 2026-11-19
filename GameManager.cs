using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loadingScreen;
    public Slider loadingBar;
    public GameObject mainMenu;
    public PlayerProfile currentProfile;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        LoadProfile();
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        float progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime * 0.5f;
            loadingBar.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    void LoadProfile()
    {
        string path = Path.Combine(Application.persistentDataPath, "profile.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            currentProfile = JsonUtility.FromJson<PlayerProfile>(json);
        }
        else
        {
            currentProfile = new PlayerProfile();
        }

        if (currentProfile.nickname == "dev_1" || string.IsNullOrEmpty(currentProfile.nickname))
        {
            currentProfile.nickname = "dev_1";
            currentProfile.isAdmin = true;
            currentProfile.hasCheat = true;
            currentProfile.hasBattlePass = true;
            Debug.Log("Брат, ты зашел как dev_1. Читы активированы!");
        }
    }

    public void SaveProfile()
    {
        string path = Path.Combine(Application.persistentDataPath, "profile.json");
        string json = JsonUtility.ToJson(currentProfile);
        File.WriteAllText(path, json);
    }
}
