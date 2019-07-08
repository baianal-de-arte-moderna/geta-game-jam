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

    [SerializeField]
    private GameObject dreamStuff = null;

    [SerializeField]
    private GameObject nightmareStuff = null;

    private static bool loaded = false;

    private static GameObjectWrapper sheepWrapper;
    private static GameObjectWrapper fenceWrapper;
    private static GameObjectWrapper haystackWrapper;
    private static List<GameObjectWrapper> wrappers;

    private static string sceneName;

    private void Awake() {
        if (!loaded) {
            sheepWrapper = InstantiateGlobal(sheepPrefab, "DreamScene");
            fenceWrapper = InstantiateGlobal(fencePrefab, "DreamScene");
            haystackWrapper = InstantiateGlobal(haystackPrefab, "CliffDreamScene");

            wrappers = new List<GameObjectWrapper> {
                sheepWrapper,
                fenceWrapper,
                haystackWrapper,
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

        if (dreamStuff != null) {
            dreamStuff.SetActive(IsDream());
        }

        if (nightmareStuff != null) {
            nightmareStuff.SetActive(!IsDream());
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

    private static bool IsDream() {
        bool isDream = false;

        string currentSceneName = SceneManager.GetActiveScene().name;
        List<GameObjectWrapper> sceneWrappers = wrappers.FindAll((GameObjectWrapper wrapper) => wrapper.instanceSceneName == currentSceneName);
        switch (currentSceneName) {
            case "DreamScene":
                isDream = sceneWrappers.Contains(sheepWrapper) && (sceneWrappers.Contains(fenceWrapper) || sceneWrappers.Contains(haystackWrapper));
                break;
            case "CliffDreamScene":
                isDream = sceneWrappers.Contains(fenceWrapper);
                break;
        }

        return isDream;
    }

    private class GameObjectWrapper {
        public GameObject gameObject;
        public string instanceSceneName;
    }
}
