/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class DreamStateController : MonoBehaviour {
    [SerializeField] private DreamState dreamState;
    [SerializeField] private DreamState nmareState;

    private DreamState currentDreamState;

    void Update() {
    }

    private void SetDream() {
        currentDreamState = dreamState;
    }

    private void SetNightmare() {
        currentDreamState = nmareState;
    }
}

public abstract class DreamState : ScriptableObject {
    [SerializeField] private Color m_lighting;
    public Color lighting => m_lighting;

    [SerializeField] private Texture m_windowBackdrop;
    public Texture windowBackdrop => m_windowBackdrop;

    [SerializeField] private AudioClip m_backgroundMusic;
    public AudioClip backgroundMusic => m_backgroundMusic;
}
