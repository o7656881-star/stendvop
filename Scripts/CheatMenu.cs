using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
    public GameObject cheatPanel;
    public Toggle wallhackToggle;
    public Toggle aimbotToggle;
    public Toggle noRecoilToggle;
    public Toggle infiniteAmmoToggle;
    public Toggle speedHackToggle;
    private PlayerProfile profile;

    void Start()
    {
        profile = GameManager.Instance.currentProfile;
        cheatPanel.SetActive(profile.hasCheat || profile.isAdmin);

        wallhackToggle.onValueChanged.AddListener(delegate { Debug.Log("WH: " + wallhackToggle.isOn); });
        aimbotToggle.onValueChanged.AddListener(delegate { Debug.Log("Aim: " + aimbotToggle.isOn); });
        noRecoilToggle.onValueChanged.AddListener(delegate { Debug.Log("NoRecoil: " + noRecoilToggle.isOn); });
        infiniteAmmoToggle.onValueChanged.AddListener(delegate { Debug.Log("InfAmmo: " + infiniteAmmoToggle.isOn); });
        speedHackToggle.onValueChanged.AddListener(delegate { Debug.Log("Speed: " + speedHackToggle.isOn); });
    }
}
