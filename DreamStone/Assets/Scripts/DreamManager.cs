using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DreamManager : MonoBehaviour {

    [SerializeField]
    private GameObject sheepPrefab;

    [SerializeField]
    private GameObject fencePrefab;

    [SerializeField]
    private GameObject haystackPrefab;

    private static bool loaded = false;
    private static List<GameObjectWrapper> wrappers;
    private static string sceneName;

    private void Awake() {
        if (!loaded) {
            wrappers = new List<GameObjectWrapper> {
                InstantiateGlobal(sheepPrefab, "DreamScene"),
                InstantiateGlobal(fencePrefab, "DreamScene"),
                InstantiateGlobal(haystackPrefab, "CliffDreamScene"),
            };
            loaded = true;
        }
    }

    private void Update() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (sceneName != currentSceneName) {
            sceneName = currentSceneName;
            foreach (GameObjectWrapper wrapper in wrappers) {
                wrapper.gameObject.SetActive(wrapper.instanceSceneName == sceneName);
            }
        }
    }

    public static void PickObject(GameObject pickedGameObject) {
        GameObjectWrapper pickedGameObjectWrapper = null;
        foreach (GameObjectWrapper wrapper in wrappers) {
            if (wrapper.gameObject == pickedGameObject) {
                pickedGameObjectWrapper = wrapper;
                break;
            }
        }

        pickedGameObjectWrapper.instanceSceneName = "PlayerInventory";
    }

    public static void DropObject(GameObject droppedGameObject) {
        GameObjectWrapper droppedGameObjectWrapper = null;
        foreach (GameObjectWrapper wrapper in wrappers) {
            if (wrapper.gameObject == droppedGameObject) {
                droppedGameObjectWrapper = wrapper;
                break;
            }
        }

        droppedGameObjectWrapper.instanceSceneName = SceneManager.GetActiveScene().name;
    }

    private GameObjectWrapper InstantiateGlobal(GameObject prefab, string instanceSceneName) {
        GameObject globalGameObject = Instantiate(prefab);
        globalGameObject.SetActive(false);
        DontDestroyOnLoad(globalGameObject);

        GameObjectWrapper wrapper = new GameObjectWrapper {
            gameObject = globalGameObject,
            instanceSceneName = instanceSceneName,
        };
        return wrapper;
    }

    public class GameObjectWrapper {
        public GameObject gameObject;
        public string instanceSceneName;
    }
}
