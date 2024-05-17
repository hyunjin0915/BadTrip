using UnityEngine;

namespace Fungus
{
    [CommandInfo("Custom",
                 "Change Cutscene",
                 "컷씬 sprite 변경")]
    [AddComponentMenu("")]
    public class ChangeCutscene : Command
    {
        [Tooltip("변경할 View의 SpriteRenderer")]
        [SerializeField] protected SpriteRenderer spriteRenderer;

        [Tooltip("변경할 sprite")]
        [SerializeField] protected Sprite sprite;

        // Start is called before the first frame update
        void Start()
        {

        }

        public override void OnEnter()
        {
            spriteRenderer.sprite = sprite;

            Continue();
        }
    }
}
