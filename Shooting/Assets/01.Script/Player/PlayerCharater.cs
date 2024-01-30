using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharater : MonoBehaviour
{
    #region MoveMent
    private Vector2 _moveInput;
    public float MoveSpeed;
    #endregion

    #region Skills
    [HideInInspector] public Dictionary<EnumTypes.PlayerSkill, BaseSkill> Skill;
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

    public void Update()
    {
        UpdateMovement();
        UPdateSkillInput();
    }

    public void InitSkillCoolDown()
    {
        foreach (var skill in Skill) { 
        
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
    }

    private void ActivateSkill(EnumTypes.PlayerSkill skillType)
    {
        InitSkillCoolDown();
    }


}