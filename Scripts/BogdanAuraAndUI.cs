using UnityEngine;
using UnityEngine.UI;

public class BogdanAuraAndUI : MonoBehaviour
{
    public Text killFeedText;
    public float auraRadius = 15f;
    public LayerMask botLayer;
    private float auraTimer = 0f;

    void Update()
    {
        PlayerProfile profile = GameManager.Instance.currentProfile;
        if (profile.nickname == "dev_1" || profile.isAdmin)
        {
            auraTimer += Time.deltaTime;
            if (auraTimer >= 1f)
            {
                Collider[] botsInRange = Physics.OverlapSphere(transform.position, auraRadius, botLayer);
                foreach (Collider botCollider in botsInRange)
                {
                    AddKillFeed("<color=red>dev_1</color> [АУРА БОГДАНА] " + botCollider.gameObject.name);
                }
                auraTimer = 0f;
            }
        }
    }

    public void AddKillFeed(string message)
    {
        if (killFeedText != null)
        {
            killFeedText.text = message + "\n" + killFeedText.text;
            if (killFeedText.text.Length > 500) killFeedText.text = killFeedText.text.Substring(0, 500);
        }
    }
}
