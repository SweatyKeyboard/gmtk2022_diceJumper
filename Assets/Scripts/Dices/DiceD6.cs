using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class DiceD6 : MonoBehaviour
{
    [SerializeField] private SpriteList _sidesSprites;
    [SerializeField] protected Color _color;
    [SerializeField] private bool _isInstantRolled = false;
    [SerializeField] private AudioClip _pickSound;
    
    private VisualDiceRolling _diceRollScreen;
    private SpriteRenderer _renderer;

    protected int _value;
    protected System.Action<int>[] _actionsList = new System.Action<int>[6];
    protected string _description;

    public System.Action<int>[] Actions => _actionsList;
    public string Description => _description;
    public int Value
    {
        get => _value;
        set => _value = value;
    }


    public SpriteList Sprites => _sidesSprites;
    public bool IsInstantRolled => _isInstantRolled;
    public Color Color => _color;
    protected void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _diceRollScreen = FindObjectOfType<VisualDiceRolling>();
        Spawn();
    }
    public void Spawn()
    {
        Value = Random.Range(1, 7);
        _renderer.sprite = _sidesSprites[Value - 1];
        _renderer.color = _color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioPlayer.PlaySound(_pickSound);
            if (_isInstantRolled)
            {
                _diceRollScreen.Roll(this);
            }
            else
            {
                Actions[0]?.Invoke(0);
            }
            Destroy(gameObject);
        }
    }
}
