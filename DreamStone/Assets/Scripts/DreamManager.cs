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

        SceneManager.LoadScene("HUDScene", LoadSceneMode.Additive);
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

        if (IsDream("DreamScene") && IsDream("CliffDreamScene")) {
            Invoke("GoToCredits", 2f);
        }
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
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

    public static string GetPickedObjectType() {
        GameObjectWrapper pickedObjectWrapper = null;
        foreach (GameObjectWrapper wrapper in wrappers) {
            if (wrapper.instanceSceneName == "PlayerInventory") {
                pickedObjectWrapper = wrapper;
                break;
            }
        }

        if (pickedObjectWrapper == sheepWrapper) {
            return "sheep";
        } else if (pickedObjectWrapper == fenceWrapper) {
            return "fence";
        } else if (pickedObjectWrapper == haystackWrapper) {
            return "haystack";
        }

        return null;
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        return IsDream(currentSceneName);
    }

    private static bool IsDream(string currentSceneName) {
        bool isDream = false;

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
