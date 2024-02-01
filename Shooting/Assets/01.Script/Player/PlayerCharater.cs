using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharater : MonoBehaviour
{
    #region MoveMent
    private Vector2 _moveInput;
    public float MoveSpeed;
    #endregion

    #region Skills
    [HideInInspector] public Dictionary<EnumTypes.PlayerSkill, BaseSkill> Skills;
    [SerializeField] private GameObject[] _skillPrefabs;
    #endregion

    #region Invincibility
    private bool invinvibility;
    private Coroutine invincibilityCoroutine;
    private const double InvincibilityDurationInSeconds = 3;

    public bool Invincibility
    {
        get { return invinvibility; } set { Invincibility = value; }
    }
    #endregion

    #region Weapon
    public int CurrentWeaponLevel = 0;
    public int MaxWeaponLevel = 3;
    #endregion

    #region AddOn
    public Transform[] AddOnTransform;
    public GameObject AddOnPrefab;
    [HideInInspector] public int MaxAddOnCount = 2;
    #endregion
    public void DeadProcess()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        InitializeSkills();
    }
    public void Update()
    {
        UpdateMovement();
        UPdateSkillInput();
    }

    public void InitSkillCoolDown()
    {
        foreach (var skill in Skills.Values) { 
            skill.InitCoolDown();
        }
    }
   /* 해야 할 것 
        매니저와 캐릭터 외우기, 
   */
    private void UpdateMovement()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
         transform.Translate(new Vector3(_moveInput.x, _moveInput.y, 0)* (MoveSpeed *Time.deltaTime));

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if(pos.x < 0) pos.x = 0;
        if(pos.x > 1) pos.x = 1;
        if(pos.y < 0) pos.y = 0;
        if(pos.y > 1) pos.y = 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    private void UPdateSkillInput()
    {
        if (Input.GetKey(KeyCode.Z)) ActivateSkill(EnumTypes.PlayerSkill.Primary);
        if (Input.GetKey(KeyCode.X)) ActivateSkill(EnumTypes.PlayerSkill.Repair);
        if (Input.GetKey(KeyCode.C)) ActivateSkill(EnumTypes.PlayerSkill.Bomb);
        if (Input.GetKey(KeyCode.V)) 
            ActivateSkill(EnumTypes.PlayerSkill.freeze);
    }

    private void InitializeSkills()
    {
        Skills = new Dictionary<EnumTypes.PlayerSkill, BaseSkill>();
        for (int i = 0; i < _skillPrefabs.Length; i++)
        {
            AddSkill((EnumTypes.PlayerSkill)i, _skillPrefabs[i]);
        }
        CurrentWeaponLevel=GameInstance.instance.CurrentPlayerWeaponLevel;
    }
    private void AddSkill(EnumTypes.PlayerSkill skillType, GameObject prefab)
    {
        GameObject SkillObject = Instantiate(prefab, transform.position, Quaternion.identity);
        SkillObject.transform.parent = this.transform;

        if (SkillObject != null)
        {
            BaseSkill skillComponent = SkillObject.GetComponent<BaseSkill>();
            skillComponent.Init(this);
            Skills.Add(skillType, skillComponent);
        }
       //
       //skillObject
    }

    private void ActivateSkill(EnumTypes.PlayerSkill skillType)
    {
         
        if (Skills.ContainsKey(skillType))
        {
            if (Skills[skillType].IsAvailable())
            {
                CurrentWeaponLevel = GameInstance.instance.CurrentPlayerWeaponLevel;
                Skills[skillType].Activate();
            }
            else
            {
                GameManager.Instance.GetComponent<PlayerUI>().NoticeSkillCooldown(skillType);
            }
        }
    }

    public void SetInvincibility(bool invin)
    {
        if (invin)
        {
            if (invincibilityCoroutine != null)// null일 경우 멈춤
            {
                StopCoroutine(invincibilityCoroutine);
            }

            invincibilityCoroutine = StartCoroutine(InvincibilityCoroutine());// 해당 함수를 실행
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        Invincibility = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float invincibilityDuration = 3f;
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(invincibilityDuration);
        Invincibility = false;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<BaseItem>().OnGetItem(this);
        }
    }
}