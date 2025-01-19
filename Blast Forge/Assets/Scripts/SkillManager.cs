using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public FireSkill fire { get; private set; }
    
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        fire = GetComponent<FireSkill>();
    }
}
